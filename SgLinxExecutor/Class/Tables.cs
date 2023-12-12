using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgLinxExecutor.Class
{
    internal class Tables
    {

        MySqlCommand command = new MySqlCommand();


        public void GerarTabelaDuplicidade(string lj)
        {
            try
            {
                string sql;
                sql = " DROP TABLE IF EXISTS DUPLICIDADES; " +
                        "CREATE TEMPORARY TABLE DUPLICIDADES AS (" +

                        "SELECT c1.rv, c1.num_cfe, c1.vl_cfe,  c1.caixa, c1.dt_doc " +
                        $"FROM log00{lj}cfe2310 c1 " +
                        "JOIN (" +
                        "   SELECT rv, COUNT(rv) AS rv_count, vl_cfe " +
                        $"FROM log00{lj}cfe2310 " +
                        "WHERE caixa = 101 " +
                        "GROUP BY rv " +
                        "HAVING COUNT(rv) > 1 " +
                        ") c2 " +
                        "ON c1.rv = c2.rv " +
                        " WHERE  c1.caixa = 101); ";
                command.CommandText = sql;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na execução do comando" + ex);
                }
 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao se conectar ao banco" + ex);
            }


        }
        public void GerarTabelaTotalVendas(string lj)
        {
            try
            {
                string sql;
                sql = "DROP TABLE IF EXISTS vendas;" +
                "CREATE TEMPORARY TABLE vendas AS ( " +
                "    SELECT cupom, caixa, data, SUM((total - desconto + acrescimo)) AS total  " +
                $"   FROM log00{lj}venda1023  " +
                "    WHERE tipo = 1 " +
                "    GROUP BY cupom, caixa, data" +
                ");";
                command.CommandText = sql;
                try
                {
                    command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                {
                    Console.WriteLine("Erro na execução do comando" + ex);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao se conectar ao banco" + ex);
            }
            
        }
    }
}
