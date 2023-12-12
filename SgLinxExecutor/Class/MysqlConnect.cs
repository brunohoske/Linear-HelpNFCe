using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using SgLinxExecutor.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SgLinxExecutor
{
    internal class MysqlConnect
    {
        private const string servidor = "localhost";
        private const string database = "sglinx";
        private const string user = "adminlinear";
        private const string pass = "@2013linear";

       
        public static string connection = $"server={servidor}; user id={user}; database={database};password={pass}; Allow User Variables=True";

        public string _connection  
        {
            get { return connection; }   
            set { connection = value; }  
        }

        private MySqlConnection connectionMysql;
        Geral Geral = new Geral();

        public bool SglinxConnect()
        {
            try
            {
                connectionMysql = new MySqlConnection(connection);
                connectionMysql.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }
       
        public void SglinxClose()
        {
            try
            {
                connectionMysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao fechar a conexão"+"\n"+ex);
            }

        }
        public bool ExecutarComando(string sql)
        {
            try
            {
                SglinxConnect();
                
                MySqlConnection mySqlConnection = new MySqlConnection(connection);

                MySqlCommand commandSql = connectionMysql.CreateCommand();

                commandSql.CommandText = sql;
                commandSql.ExecuteNonQuery();

                
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na execução"+"\n"+ex);
                return false;
            }
            finally
            {
                SglinxClose();

                
            }
            
        }
        public string[] CaixasCad(int lj)
        {

            if (SglinxConnect())
            {
                try
                {
                    MySqlCommand command = connectionMysql.CreateCommand();
                    MySqlDataReader reader;

                    List<string> caixas = new List<string>();
                    string sql = $"SELECT caixa FROM cadecf WHERE tipo <> 1 AND filial = {lj} group by caixa;"; ;
                    command.CommandText = sql;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        caixas.Add(reader["caixa"].ToString());
                    }
                    return caixas.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

            }
            else
            {
                
                return null;
            }

        }
        public string[] EmpresasCad()
        {

            if (SglinxConnect())
            {
                try
                {
                    MySqlCommand command = connectionMysql.CreateCommand();
                    MySqlDataReader reader;

                    List<string> empresas = new List<string>();
                    string sql = $"SELECT emp_codigo FROM empresa;";
                    command.CommandText = sql;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        empresas.Add(reader["emp_codigo"].ToString());
                    }
                    return empresas.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    SglinxClose();
                }

            }
            else
            {
                
                return null;

            }
            

        }
        public void AlterIp(string ip)
        {
            connection = $"server={ip}; user id={user}; database={database};password={pass}; Allow User Variables=True";
        }

        //duplicidades RV com valor diferente -- resolver tudo
        public bool DuplicidadeRV(string lj, string dt, string cx)
        {
            try
            {
                SglinxConnect();


                try
                {
                    int cont = 0;
                    string dt2 = Geral.InverterData(dt);

                    string sql = "";

                    if (lj.ToCharArray().Length == 1)
                    {
                        sql = "DROP TABLE IF EXISTS DUPLICIDADES;" +
                              "CREATE TEMPORARY TABLE DUPLICIDADES AS ( " +
                              "SELECT c1.rv, c1.num_cfe, c1.vl_cfe,  c1.caixa, c1.dt_doc " +
                             $"FROM log00{lj}cfe{dt2} c1 " +
                              "JOIN ( " +
                              "   SELECT rv, COUNT(rv) AS rv_count, vl_cfe,num_cfe " +
                             $"FROM log00{lj}cfe{dt2}" +
                             $"   WHERE caixa = {cx} " +
                              "GROUP BY rv " +
                              "HAVING COUNT(rv) > 1 " +
                              ") c2 ON c1.rv = c2.rv " +
                             $"   WHERE  c1.caixa = {cx} " +
                             $"   AND c1.num_cfe <> c2.num_cfe " +
                             $"   AND c1.cod_sit <> 05 " +
                             $"   AND c1.cod_sit <> 02 " +
                              "); " +
                              "DROP TABLE IF EXISTS vendas; " +
                              "CREATE TEMPORARY TABLE vendas AS ( " +
                              "    SELECT cupom, caixa, data, SUM((total - desconto + acrescimo)) AS total  " +
                             $"    FROM log00{lj}venda{dt}  " +
                              "    WHERE tipo = 1 " +
                              "    GROUP BY cupom, caixa, data " +
                              "); " +
                              "CREATE INDEX idx_vendas " +
                              "ON vendas(cupom,total); " +
                              "CREATE INDEX idx_cfe " +
                              "ON duplicidades(num_cfe,rv,vl_cfe,dt_doc,caixa); " +
                              "SELECT c.num_cfe, c.rv, c.dt_doc, c.caixa " +
                              "FROM duplicidades c left JOIN vendas v " +
                              "ON v.cupom = c.rv  " +
                              "AND v.caixa = c.caixa " +
                              "AND v.data = c.dt_doc " +
                              "WHERE c.vl_cfe <> v.total " +
                              "AND c.rv = v.cupom; " +
                              "DROP INDEX idx_vendas ON vendas;  " +
                              "DROP INDEX idx_cfe ON duplicidades;";
                    }
                    if (lj.ToCharArray().Length == 2)
                    {
                        sql = "DROP TABLE IF EXISTS DUPLICIDADES;" +
                             "CREATE TEMPORARY TABLE DUPLICIDADES AS ( " +
                             "SELECT c1.rv, c1.num_cfe, c1.vl_cfe,  c1.caixa, c1.dt_doc " +
                            $"FROM log0{lj}cfe{dt2} c1 " +
                             "JOIN ( " +
                             "   SELECT rv, COUNT(rv) AS rv_count, vl_cfe " +
                            $"FROM log0{lj}cfe{dt2}" +
                            $"   WHERE caixa = {cx} " +
                             "GROUP BY rv " +
                             "HAVING COUNT(rv) > 1 " +
                             ") c2 ON c1.rv = c2.rv " +
                            $"   WHERE  c1.caixa = {cx} " +
                             "); " +
                             "DROP TABLE IF EXISTS vendas; " +
                             "CREATE TEMPORARY TABLE vendas AS ( " +
                             "    SELECT cupom, caixa, data, SUM((total - desconto + acrescimo)) AS total  " +
                            $"    FROM log0{lj}venda{dt}  " +
                             "    WHERE tipo = 1 " +
                             "    GROUP BY cupom, caixa, data " +
                             "); " +
                             "CREATE INDEX idx_vendas " +
                             "ON vendas(cupom,total); " +
                             "CREATE INDEX idx_cfe " +
                             "ON duplicidades(num_cfe,rv,vl_cfe,dt_doc,caixa); " +
                             "SELECT c.num_cfe, c.rv, c.dt_doc, c.caixa " +
                             "FROM duplicidades c left JOIN vendas v " +
                             "ON v.cupom = c.rv  " +
                             "AND v.caixa = c.caixa " +
                             "AND v.data = c.dt_doc " +
                             "WHERE c.vl_cfe <> v.total " +
                             "AND c.rv = v.cupom; " +
                             "DROP INDEX idx_vendas ON vendas;  " +
                             "DROP INDEX idx_cfe ON duplicidades;";
                    }
                    if (lj.ToCharArray().Length == 3)
                    {
                         sql = "DROP TABLE IF EXISTS DUPLICIDADES;" +
                              "CREATE TEMPORARY TABLE DUPLICIDADES AS ( " +
                              "SELECT c1.rv, c1.num_cfe, c1.vl_cfe,  c1.caixa, c1.dt_doc " +
                             $"FROM log{lj}cfe{dt2} c1 " +
                              "JOIN ( " +
                              "   SELECT rv, COUNT(rv) AS rv_count, vl_cfe " +
                             $"FROM log{lj}cfe{dt2}" +
                             $"   WHERE caixa = {cx} " +
                              "GROUP BY rv " +
                              "HAVING COUNT(rv) > 1 " +
                              ") c2 ON c1.rv = c2.rv " +
                             $"   WHERE  c1.caixa = {cx} " +
                              "); " +
                              "DROP TABLE IF EXISTS vendas; " +
                              "CREATE TEMPORARY TABLE vendas AS ( " +
                              "    SELECT cupom, caixa, data, SUM((total - desconto + acrescimo)) AS total  " +
                             $"    FROM log{lj}venda{dt}  " +
                              "    WHERE tipo = 1 " +
                              "    GROUP BY cupom, caixa, data " +
                              "); " +
                              "CREATE INDEX idx_vendas " +
                              "ON vendas(cupom,total); " +
                              "CREATE INDEX idx_cfe " +
                              "ON duplicidades(num_cfe,rv,vl_cfe,dt_doc,caixa); " +
                              "SELECT c.num_cfe, c.rv, c.dt_doc, c.caixa " +
                              "FROM duplicidades c left JOIN vendas v " +
                              "ON v.cupom = c.rv  " +
                              "AND v.caixa = c.caixa " +
                              "AND v.data = c.dt_doc " +
                              "WHERE c.vl_cfe <> v.total " +
                              "AND c.rv = v.cupom; " +
                              "DROP INDEX idx_vendas ON vendas;  " +
                              "DROP INDEX idx_cfe ON duplicidades;";
                    }


                    MySqlCommand commandSql = connectionMysql.CreateCommand();
                    commandSql.CommandText = sql;
                    MySqlDataReader reader = commandSql.ExecuteReader();


                    List<string> iNumCfe = new List<string>();
                    List<string> rv = new List<string>();
                    List<int> CnumCfe = new List<int>();
                    List<DateTime> dtDoucument = new List<DateTime>();
                    List<string> caixa = new List<string>();


                    while (reader.Read())
                    {
                        iNumCfe.Add(reader["num_cfe"].ToString());
                        rv.Add(reader["rv"].ToString());
                        dtDoucument.Add((DateTime)reader["dt_doc"]);
                        caixa.Add(reader["caixa"].ToString());
                        cont++;
                    }
                    MessageBox.Show($"{cont} registros encontrados.");
                    reader.Close();

                    #region antigo
                    //for (int i = 0; i < InumCfe.Count; i++)
                    //{
                    //    string select = $"select num_cfe" +
                    //                    $" from log001cfe2310" +
                    //                    $" Where rv = {rv[i]}";

                    //    try
                    //    {

                    //        MySqlCommand command2 = connectionMysql.CreateCommand();
                    //        command2.CommandText = select;
                    //        //MySqlDataReader reader2 = command2.ExecuteReader();
                    //        reader = command2.ExecuteReader();


                    //        while (reader.Read())
                    //        {
                    //            if (!InumCfe.Contains(reader["num_cfe"].ToString()))
                    //            {
                    //                CnumCfe.Add(reader["num_cfe"].ToString());
                    //            }

                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show("Erro na execução do comando:" + ex);
                    //        throw;
                    //    }
                    //}
                    //reader.Close();

                    //deletes
                    //for (int i = 0; i < rv.Count; i++)
                    //{
                    //    ExecutarComando($"delete from log001venda1023 where caixa = 102 and cupom = {rv[i]};" +
                    //                    $"delete from log001fin2310 where caixa = 102 and cupom = {rv[i]};");
                    //}
                    #endregion

                    //update e inserts
                    if (lj.ToCharArray().Length == 1)
                    {
                        for (int i = 0; i < iNumCfe.Count; i++)
                        {
                            if (ExecutarComando($"update log00{lj}cfe{dt2} SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log00{lj}cfe{dt2}trib SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log00{lj}cfe{dt2}pis SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]};"))
                            {
                                if (ExecutarComando($"SET @loja = '00{lj}'; " +
                                                $"SET @data = '{dtDoucument[i]:yyyy-MM-dd}'; " +
                                                $"SET @caixa = {caixa[i]}; " +
                                                $"INSERT INTO log00{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado) " +
                                                $"SELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log00{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {iNumCfe[i]}; "))
                                {
                                    
                                    ExecutarComando($"INSERT INTO LOG00{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado) " +
                                        $"SELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco, " +
                                        $"SUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc, " +
                                        $"'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado " +
                                        $"from LOG00{lj}venda{dt} v " +
                                        $"WHERE v.cupom = {(int.Parse(rv[i]) + 20000)} AND v.tipo = 1 " +
                                        $"group by caixa,cupom");
                                }
                            }
                        }
                    }
                    if (lj.ToCharArray().Length == 2)
                    {
                        for (int i = 0; i < iNumCfe.Count; i++)
                        {
                            if (ExecutarComando($"update log0{lj}cfe{dt2} SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log0{lj}cfe{dt2}trib SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log0{lj}cfe{dt2}pis SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]};"))
                            {
                                if (ExecutarComando($"SET @loja = '00{lj}'; " +
                                                $"SET @data = '{dtDoucument[i]:yyyy-MM-dd}'; " +
                                                $"SET @caixa = {caixa[i]}; " +
                                                $"INSERT INTO log0{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado) " +
                                                $"SELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log0{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {iNumCfe[i]}; "))
                                {
                                    ExecutarComando($"INSERT INTO LOG0{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado) " +
                                        $"SELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco, " +
                                        $"SUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc, " +
                                        $"'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado " +
                                        $"from LOG0{lj}venda{dt} v " +
                                        $"WHERE v.cupom = {(int.Parse(rv[i]) + 20000)} AND v.tipo = 1 " +
                                        $"group by caixa,cupom");
                                }
                            }
                        }
                    }
                    if (lj.ToCharArray().Length == 3)
                    {
                        for (int i = 0; i < iNumCfe.Count; i++)
                        {
                            if (ExecutarComando($"update log{lj}cfe{dt2} SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log{lj}cfe{dt2}trib SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]}; " +
                                            $"update log{lj}cfe{dt2}pis SET rv = rv+20000 WHERE caixa = {caixa[i]} AND dt_doc = '{dtDoucument[i]:yyyy-MM-dd}' AND num_cfe = {iNumCfe[i]};"))
                            {
                                if (ExecutarComando($"SET @loja = '00{lj}'; " +
                                                $"SET @data = '{dtDoucument[i]:yyyy-MM-dd}'; " +
                                                $"SET @caixa = {caixa[i]}; " +
                                                $"INSERT INTO log{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado) " +
                                                $"SELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log{lj}cfe{dt}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {iNumCfe[i]}; "))
                                {
                                    ExecutarComando($"INSERT INTO LOG{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado) " +
                                        $"SELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco, " +
                                        $"SUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc, " +
                                        $"'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado " +
                                        $"from LOG{lj}venda{dt} v " +
                                        $"WHERE v.cupom = {(int.Parse(rv[i]) + 20000)} AND v.tipo = 1 " +
                                        $"group by caixa,cupom");
                                }
                            }
                        }
                    }

                    #region antigo
                    //for (int i = 0; i < CnumCfe.Count; i++)
                    //{
                    //    if (ExecutarComando($"update log001cfe2310 SET rv = rv+10000 WHERE caixa = 102 AND dt_doc = '2023-10-01' AND num_cfe = {CnumCfe[i]}; " +
                    //                        $"update log001cfe2310trib SET rv = rv+10000 WHERE caixa = 102 AND dt_doc = '2023-10-01' AND num_cfe ={CnumCfe[i]}; " +
                    //                        $"update log001cfe2310pis SET rv = rv+10000 WHERE caixa = 102 AND dt_doc = '2023-10-01' AND num_cfe = {CnumCfe[i]};"))
                    //    {
                    //        if (ExecutarComando($"SET @loja = '001'; " +
                    //                       $"SET @data = '2023-10-01'; " +
                    //                       $"SET @caixa = 102; " +
                    //                       $"INSERT INTO log001venda1023 (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado) " +
                    //                       $"SELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log001cfe2310trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {CnumCfe[i]}; "))
                    //        {
                    //            ExecutarComando($"INSERT INTO LOG001fin2310 (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado) " +
                    //                        $"SELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco, " +
                    //                        $"SUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc, " +
                    //                        $"'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado " +
                    //                        $"from LOG001venda1023 v " +
                    //                        $"WHERE v.cupom = {rv[i] + 20000} AND v.tipo = 1 " +
                    //                        $"group by caixa,cupom");
                    //                }
                    //    }
                    //}
                    #endregion

                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.Contains("Table") && ex.Message.Contains("doesn't exist"))
                    {
                        MessageBox.Show("Confira o mês inserido");
                    }
                    else
                    {
                        MessageBox.Show($"Exception: {ex}");
                    }
                    
                    return false;


                }


            }
            catch (MySqlException ex)
            {



                MessageBox.Show("Ocorreu um erro na conexão" + "\n" + ex);
                return false;
            }
            finally
            {

                SglinxClose();


            }

        }

      

    }
}
