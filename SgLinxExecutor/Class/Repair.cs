using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SgLinxExecutor
{
    internal class Repair
    {
        MysqlConnect mysqlConnect = new MysqlConnect();
        public void RepairGeralNfce(bool vLojas,string dt, string lj)
        {
            Geral geral = new Geral();
            string dt2 = geral.InverterData(dt);
            try
            {
                
                if (mysqlConnect.SglinxConnect())
                {
                    try
                    {
                        if(!vLojas)
                        {
                            if (lj.ToCharArray().Length == 1)
                            {
                                if (mysqlConnect.ExecutarComando(
                                $"repair table log00{lj}cfe{dt2};" +
                                $"repair table log00{lj}cfe{dt2}trib;" +
                                $"repair table log00{lj}cfe{dt2}pis;" +
                                $"repair table log00{lj}venda{dt};" +
                                $"repair table log00{lj}fin{dt2};" +
                                $"repair table wslinear{dt}_arqs;")
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                                else
                                {
                                    MessageBox.Show("Erro na execução, confira os valores digitados");
                                }
                            }
                            else if (lj.ToCharArray().Length == 2)
                            {
                                if (mysqlConnect.ExecutarComando(
                                $"repair table log0{lj}cfe{dt2};" +
                                $"repair table log0{lj}cfe{dt2}trib;" +
                                $"repair table log0{lj}cfe{dt2}pis;" +
                                $"repair table log0{lj}venda{dt};" +
                                $"repair table log0{lj}fin{dt2};" +
                                $"repair table wslinear{dt}_arqs;")
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                            }
                            else
                            {
                                if (mysqlConnect.ExecutarComando(
                                $"repair table log{lj}cfe{dt2};" +
                                $"repair table log{lj}cfe{dt2}trib;" +
                                $"repair table log{lj}cfe{dt2}pis;" +
                                $"repair table log{lj}venda{dt};" +
                                $"repair table log{lj}fin{dt2};" +
                                $"repair table wslinear{dt}_arqs;")
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                            }
                        }

                        else
                        {
                            for(int i = 1; i <= int.Parse(lj); i++)
                            {
                                if(i > 0 && i < 10)
                                {
                                    if (mysqlConnect.ExecutarComando(
                                    $"repair table log00{i}cfe{dt2};" +
                                    $"repair table log00{i}cfe{dt2}trib;" +
                                    $"repair table log00{i}cfe{dt2}pis;" +
                                    $"repair table log00{i}venda{dt};" +
                                    $"repair table log00{i}fin{dt2};" +
                                    $"repair table wslinear{dt}_arqs;")
                                    )
                                    {
                                        MessageBox.Show($"Comando na loja {i} executado com sucesso! ");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erro na execução, confira os valores digitados");
                                    }

                                }
                                else if(i > 9 && i < 100)
                                {
                                    if (mysqlConnect.ExecutarComando(
                                    $"repair table log0{i}cfe{dt2};" +
                                    $"repair table log0{i}cfe{dt2}trib;" +
                                    $"repair table log0{i}cfe{dt2}pis;" +
                                    $"repair table log0{i}venda{dt};" +
                                    $"repair table log0{i}fin{dt2};" +
                                    $"repair table wslinear{dt}_arqs;")
                                    )
                                    {
                                        MessageBox.Show($"Comando na loja {i} executado com sucesso! ");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erro na execução, confira os valores digitados");
                                    }
                                }
                                else if(i > 99 && i < 1000)
                                {
                                    if (mysqlConnect.ExecutarComando(
                                    $"repair table log{i}cfe{dt2};" +
                                    $"repair table log{i}cfe{dt2}trib;" +
                                    $"repair table log{i}cfe{dt2}pis;" +
                                    $"repair table log{i}venda{dt};" +
                                    $"repair table log{i}fin{dt2};" +
                                    $"repair table wslinear{dt}_arqs;")
                                    )
                                    {
                                        MessageBox.Show($"Comando na loja {i} executado com sucesso! ");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erro na execução, confira os valores digitados");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Erro na execução, confira os valores digitados");
                                }
                            }
                        }
                        
                        
                    }
                    catch ( Exception e )
                    {
                        MessageBox.Show("Exceção: "+e.Message);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção: " + ex.Message);
            }
            
        }
    }
}
