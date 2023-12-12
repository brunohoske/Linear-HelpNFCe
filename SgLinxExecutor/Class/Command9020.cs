using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SgLinxExecutor
{
    internal class Command9020
    {
        MysqlConnect mysqlConnect = new MysqlConnect();
        Geral geral = new Geral();
        MySqlConnection connectionMysql;




        public bool Executar9020(string lj, string dt, string cx, string cp)
        {
            
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    try
                    {
                        string dt2 = geral.InverterData(dt);

                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando(
                                    "UPDATE" +
                                    $" log00{lj}fin{dt2} " +
                                    "SET" +
                                    $" valorliq = (SELECT SUM(TOTAL-DESCONTO) FROM LOG00{lj}VENDA{dt} WHERE CAIXA = {cx} AND CUPOM = {cp} AND TIPO = 1) WHERE caixa = {cx} AND cupom = {cp}")
                                )
                            {
                                // MessageBox.Show("Comando executado com sucesso");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando(
                                "UPDATE " +
                                $"log0{lj}fin{dt2}" +
                                " SET " +
                                $"valorliq = (SELECT SUM(TOTAL-DESCONTO) FROM LOG0{lj}VENDA{dt} WHERE CAIXA = {cx} AND CUPOM = {cp} AND TIPO = 1) WHERE caixa = {cx} AND cupom = {cp}")
                                )
                            {
                                // MessageBox.Show("Comando executado com sucesso");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando(
                                "UPDATE" +
                                $" log{lj}fin{dt2} " +
                                "SET " +
                                $"valorliq = (SELECT SUM(TOTAL-DESCONTO) FROM LOG{lj}VENDA{dt} WHERE CAIXA = {cx} AND CUPOM = {cp} AND TIPO = 1) WHERE caixa = {cx} AND cupom = {cp}")
                                )
                            {
                               // MessageBox.Show("Comando executado com sucesso");
                               return true;

                            }
                            else
                            {
                                return false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao conectar no banco de dados Sglinx");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
                return false;
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }
            
        }
        public void ExecutarFull9020(string lj, string dt)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    try
                    {
                        string dt2 = geral.InverterData(dt);

                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando(
                               //$"UPDATE log00{lj}fin{dt2} set  valorliq = valor WHERE valorliq != valor;"))
                               $"UPDATE" +
                                $" log00{lj}fin{dt2} f " +
                               $"INNER JOIN " +
                                $"log00{lj}cfe{dt2} c " +
                               $"SET " +
                                $"f.valorliq = c.vl_cfe " +
                               $"WHERE " +
                                $"f.valorliq != c.vl_cfe AND c.rv = f.cupom  AND c.caixa = f.caixa;"))
                            {
                                MessageBox.Show("Comando executado com sucesso");
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando(
                                //$"UPDATE log0{lj}fin{dt2} set valorliq = valor WHERE valorliq != valor;"))
                               $"UPDATE " +
                                $"log0{lj}fin{dt2} f " +
                               $"INNER JOIN " +
                                $"log0{lj}cfe{dt2} c " +
                               $"SET " +
                                $"f.valorliq = c.vl_cfe " +
                               $"WHERE " +
                                $"f.valorliq != c.vl_cfe AND c.rv = f.cupom  AND c.caixa = f.caixa;"))
                            {
                                MessageBox.Show("Comando executado com sucesso");
                            }
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando(
                                //$"UPDATE log{lj}fin{dt2} set  valorliq = valor WHERE valorliq != valor;"))
                               $"UPDATE " +
                                $"log{lj}fin{dt2} f " +
                               $"INNER JOIN " +
                                $"log{lj}cfe{dt2} c " +
                               $"SET " +
                                $"f.valorliq = c.vl_cfe " +
                               $"WHERE " +
                                $"f.valorliq != c.vl_cfe AND c.rv = f.cupom  AND c.caixa = f.caixa;"))
                            {
                                MessageBox.Show("Comando executado com sucesso");
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }
        }

        //Logvenda dif logfin
        public void ExecutarDivLogvendalogfin(string lj, string dt, string cx, string cp)
        {
            string dt2 = geral.InverterData(dt);
            try
            {
                if(mysqlConnect.SglinxConnect())
                {
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"repair table log00{lj}cfe{dt2}trib; repair table log00{lj}venda{dt};"))
                            {

                                if (mysqlConnect.ExecutarComando(
                                    $"SET @rv = {cp};" +
                                    $"SET @caixa = {cx};" +
                                    "UPDATE " +
                                    $"LOG00{lj}venda{dt} inner join log00{lj}cfe{dt2}trib " +
                                    "on " +
                                    $"LOG00{lj}venda{dt}.cupom = log00{lj}cfe{dt2}trib.rv" +
                                    " and " +
                                    $"LOG00{lj}venda{dt}.codprod = log00{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG00{lj}venda{dt}.quant = log00{lj}cfe{dt2}trib.quant" +
                                    " AND " +
                                    $"LOG00{lj}venda{dt}.caixa = log00{lj}cfe{dt2}trib.caixa " +
                                    "set " +
                                    $"desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG00{lj}venda{dt}.caixa = @caixa AND rv = @rv;" +
                                    "UPDATE" +
                                    $" LOG00{lj}venda{dt} inner join log00{lj}cfe{dt2}trib" +
                                    " on" +
                                    $" LOG00{lj}venda{dt}.cupom = log00{lj}cfe{dt2}trib.rv" +
                                    " and" +
                                    $" LOG00{lj}venda{dt}.codprod = log00{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG00{lj}venda{dt}.quant = log00{lj}cfe{dt2}trib.quant" +
                                    " AND" +
                                    $" LOG00{lj}venda{dt}.caixa = log00{lj}cfe{dt2}trib.caixa " +
                                    "AND " +
                                    $"LOG00{lj}venda{dt}.item = log00{lj}cfe{dt2}trib.item" +
                                    " set" +
                                    $" desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG00{lj}venda{dt}.caixa = @caixa AND rv = @rv;"
                                    )
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso!");
                                }
                            }
                        }
                        if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando($"repair table log00{lj}cfe{dt2}trib; repair table log00{lj}venda{dt};"))
                            {

                                if (mysqlConnect.ExecutarComando(
                                    $"SET @rv = {cp};" +
                                    $"SET @caixa = {cx};" +
                                    "UPDATE " +
                                    $"LOG0{lj}venda{dt} inner join log0{lj}cfe{dt2}trib " +
                                    "on " +
                                    $"LOG0{lj}venda{dt}.cupom = log0{lj}cfe{dt2}trib.rv" +
                                    " and " +
                                    $"LOG0{lj}venda{dt}.codprod = log0{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG0{lj}venda{dt}.quant = log0{lj}cfe{dt2}trib.quant" +
                                    " AND " +
                                    $"LOG0{lj}venda{dt}.caixa = log0{lj}cfe{dt2}trib.caixa " +
                                    "set " +
                                    $"desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG0{lj}venda{dt}.caixa = @caixa AND rv = @rv;" +
                                    "UPDATE" +
                                    $" LOG0{lj}venda{dt} inner join log0{lj}cfe{dt2}trib" +
                                    " on" +
                                    $" LOG0{lj}venda{dt}.cupom = log0{lj}cfe{dt2}trib.rv" +
                                    " and" +
                                    $" LOG0{lj}venda{dt}.codprod = log0{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG0{lj}venda{dt}.quant = log0{lj}cfe{dt2}trib.quant" +
                                    " AND" +
                                    $" LOG0{lj}venda{dt}.caixa = log0{lj}cfe{dt2}trib.caixa " +
                                    "AND " +
                                    $"LOG0{lj}venda{dt}.item = log0{lj}cfe{dt2}trib.item" +
                                    " set" +
                                    $" desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG0{lj}venda{dt}.caixa = @caixa AND rv = @rv;"
                                    )
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso!");
                                }
                            }
                        }
                        if (lj.ToCharArray().Length == 3)
                        {
                            if (mysqlConnect.ExecutarComando($"repair table log00{lj}cfe{dt2}trib; repair table log00{lj}venda{dt};"))
                            {

                                if (mysqlConnect.ExecutarComando(
                                    $"SET @rv = {cp};" +
                                    $"SET @caixa = {cx};" +
                                    "UPDATE " +
                                    $"LOG{lj}venda{dt} inner join log{lj}cfe{dt2}trib " +
                                    "on " +
                                    $"LOG{lj}venda{dt}.cupom = log{lj}cfe{dt2}trib.rv" +
                                    " and " +
                                    $"LOG{lj}venda{dt}.codprod = log{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG{lj}venda{dt}.quant = log{lj}cfe{dt2}trib.quant" +
                                    " AND " +
                                    $"LOG{lj}venda{dt}.caixa = log{lj}cfe{dt2}trib.caixa " +
                                    "set " +
                                    $"desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG00{lj}venda{dt}.caixa = @caixa AND rv = @rv;" +
                                    "UPDATE" +
                                    $" LOG{lj}venda{dt} inner join log{lj}cfe{dt2}trib" +
                                    " on" +
                                    $" LOG{lj}venda{dt}.cupom = log{lj}cfe{dt2}trib.rv" +
                                    " and" +
                                    $" LOG{lj}venda{dt}.codprod = log{lj}cfe{dt2}trib.codprod" +
                                    " and " +
                                    $"LOG{lj}venda{dt}.quant = log{lj}cfe{dt2}trib.quant" +
                                    " AND" +
                                    $" LOG{lj}venda{dt}.caixa = log{lj}cfe{dt2}trib.caixa " +
                                    "AND " +
                                    $"LOG{lj}venda{dt}.item = log{lj}cfe{dt2}trib.item" +
                                    " set" +
                                    $" desconto = total - vl_opr where total-vl_opr <> desconto AND tipo = 1 and LOG00{lj}venda{dt}.caixa = @caixa AND rv = @rv;"
                                    )
                                )
                                {
                                    MessageBox.Show("Comando executado com sucesso!");
                                }
                            }
                        }
                    }
                    catch (Exception e) 
                    {
                        MessageBox.Show("Exceção:" + e.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção:" + ex.Message);
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }
        }
        public void ExecutarFullDivLogvendalogfin(string lj, string dt, string cx, string cp)
        {
            string dt2 = geral.InverterData(dt);

            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    try
                    {

                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"repair table log0{lj}cfe{dt2}trib; repair table log0{lj}venda{dt};"))
                            {
                                if (mysqlConnect.ExecutarComando($"UPDATE " +
                                $"log00{lj}venda{dt} as v inner join log00{lj}cfe{dt2}trib as t " +
                                $"on v.cupom = t.rv " +
                                $"and v.codprod = t.codprod " +
                                $"and v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.cupom = t.rv; " +
                                $"UPDATE log00{lj}venda{dt} as v inner join log00{lj}cfe{dt2}trib as t " +
                                $"ON v.cupom = t.rv " +
                                $"AND v.codprod = t.codprod " +
                                $"AND v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.item = t.item " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND t.rv = v.cupom;"))

                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                            }
                                
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if(mysqlConnect.ExecutarComando($"repair table log0{lj}cfe{dt2}trib; repair table log0{lj}venda{dt};"))
                            {
                                if (mysqlConnect.ExecutarComando($"UPDATE " +
                                $"log0{lj}venda{dt} as v inner join log0{lj}cfe{dt2}trib as t " +
                                $"on v.cupom = t.rv " +
                                $"and v.codprod = t.codprod " +
                                $"and v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.cupom = t.rv; " +
                                $"UPDATE log0{lj}venda{dt} as v inner join log0{lj}cfe{dt2}trib as t " +
                                $"ON v.cupom = t.rv " +
                                $"AND v.codprod = t.codprod " +
                                $"AND v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.item = t.item " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND t.rv = v.cupom;"))
                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                            }
                            
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando($"repair table log{lj}cfe{dt2}trib; repair table log{lj}venda{dt};"))
                            {
                                if (mysqlConnect.ExecutarComando($"UPDATE " +
                                $"log{lj}venda{dt} as v inner join log{lj}cfe{dt2}trib as t " +
                                $"on v.cupom = t.rv " +
                                $"and v.codprod = t.codprod " +
                                $"and v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.cupom = t.rv; " +
                                $"UPDATE log{lj}venda{dt} as v inner join log{lj}cfe{dt2}trib as t " +
                                $"ON v.cupom = t.rv " +
                                $"AND v.codprod = t.codprod " +
                                $"AND v.quant = t.quant " +
                                $"AND v.caixa = t.caixa " +
                                $"AND v.item = t.item " +
                                $"set desconto = total - vl_opr " +
                                $"where total-vl_opr <> desconto " +
                                $"AND tipo = 1 " +
                                $"AND v.caixa = t.caixa " +
                                $"AND t.rv = v.cupom;"))
                                {
                                    MessageBox.Show("Comando executado com sucesso");
                                }
                            }
                                
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:" + "\n" + ex);
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }

        }


        #region Inserts
        //Insert into LogVenda
        public bool InserirLogVenda(string lj, string dt, string dataPicker, string cx, string nfce)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '00{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log00{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log00{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {nfce};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '0{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log0{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log0{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {nfce};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else 
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe = {nfce};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:"+ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }

            
        }
        public bool InserirSequenciaLogVenda(string lj, string dt, string dataPicker, string cx, string nfceIni, string nfceFin)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '00{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log00{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log00{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe BETWEEN {nfceIni} AND {nfceFin};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '0{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log0{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log0{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe BETWEEN {nfceIni} AND {nfceFin};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando($"SET @loja = '{lj}'; SET @data = '{dataPicker}';\r\nSET @caixa = {cx};\r\n\r\nINSERT INTO log{lj}venda{dt} (tipo, cupom, data, caixa, loja, item, codbusca, quant, prunit, tributo, desconto, tpdesc, total, totdesc, codprod, familia, departamento, es1_prcompra, es1_prcusto, codcli, margem, CMV, vendedor, comanda, operador, hora, promo, comissao, acrescimo, es1_piscofins, reproccanc, mfd, criptografia, codcomposto, es1_cstpis, pis_natreceita, consumidor, operador_atualizado, tipo_promo, promo_retroativo, datahoravendaitem, datahoracancelamentoitem, motivodesconto, estoque_estornado, estoque_baixado)\r\n\r\nSELECT '1', LPAD(rv, 6, '0'), dt_doc, caixa, @loja, LPAD(item, 6, '0'), es1p.es1_codbarra, quant, (vl_opr/quant) AS vl_un, codpdv, 0.00, '', vl_opr, 0.00, codprod, es1_familia, es1_departamento, es1.es1_prcompra, es1.es1_custo, 0, es1.es1_margemcom, es1.es1_prcompra, 0,0,99,NULL, 0,0.00,0.00, es1.es1_pisconfins, 0,0,'',0,es1.es1_cstpisent, es1.pis_natreceita, '', 0,0,0, NULL, NULL, 0,0,0 FROM log{lj}cfe{dt2}trib INNER JOIN es1 ON codprod = es1.es1_cod INNER JOIN es1p ON codprod = es1p.es1_cod INNER JOIN icms ON es1_tributacao = codigo WHERE dt_doc = @data AND caixa = @caixa AND es1.es1_empresa = @loja AND num_cfe BETWEEN {nfceIni} AND {nfceFin};"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:" + ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }
        }


        //Insert into LogFin

        public bool InserirLogFin(string lj, string dt,string cp)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG00{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG00{lj}venda{dt} v\r\nWHERE v.cupom = {cp} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG0{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG0{lj}venda{dt} v\r\nWHERE v.cupom = {cp} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG{lj}venda{dt} v\r\nWHERE v.cupom = {cp} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:" + ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }


        }

        public bool InserirSequenciaLogFin(string lj, string dt, string cpIni, string cpFin)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG00{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG00{lj}venda{dt} v\r\nWHERE v.cupom BETWEEN {cpIni} AND {cpFin} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG0{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG0{lj}venda{dt} v\r\nWHERE v.cupom BETWEEN {cpIni} AND {cpFin} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (mysqlConnect.ExecutarComando($"INSERT INTO LOG{lj}fin{dt2} (tipo, cupom, caixa, codigo, descricao, valor, troco, valorliq, desconto, totdesc, tpdesc, dataimporta, horaimporta,DATA,operador,nome,empresa,hora, operadorlibera,operador_atualizado)\r\n\r\nSELECT 3 AS tipo, v.cupom AS cupom, v.caixa, '01' AS codigo, 'DINHEIRO' AS descricao, SUM(total) AS total, 0 AS troco,\r\nSUM(v.total-v.desconto+v.acrescimo) AS valorliq, SUM(v.desconto) AS desconto, SUM(v.desconto+v.acrescimo) AS totdesc,\r\n'' AS tpdesc, v.data AS dataimporta, '07' AS horaimporta, DATA, '999' AS operador, 'LINEAR' AS nome, 1 AS empresa, '09:00:00' AS hora, '0' AS operadorlibera, 1 AS operador_atualizado from\r\nLOG{lj}venda{dt} v\r\nWHERE v.cupom BETWEEN {cpIni} AND {cpFin} AND v.tipo = 1\r\ngroup by caixa,cupom"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:" + ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }
            finally
            {
                mysqlConnect.SglinxClose();
            }
        }

        //Insert into LogVenda e Logfin (ao mesmo tempo)

        public bool InserirLogVendaFin(string lj, string dt, string dataPicker, string cx, string nfce)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {

                        if (lj.ToCharArray().Length == 1)
                        {
                            mysqlConnect.SglinxClose();
                            connectionMysql = new MySqlConnection(mysqlConnect._connection);
                            connectionMysql.Open();
                            if (InserirLogVenda(lj,dt,dataPicker,cx,nfce))
                            {
                                
                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG00{lj}CFE{dt2} WHERE NUM_CFE = {nfce} ";

                                try
                                {
                                    MySqlCommand commandSql = connectionMysql.CreateCommand();
                                    commandSql.CommandText = sql;
                                    MySqlDataReader reader = commandSql.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        rv.Add(reader["rv"].ToString());
                                    }
                                    reader.Close();
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                                if (InserirLogFin(lj, dt, rv[0]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false; 
                                }
                            }
                            else
                            {
                                return false;
                            }
                            
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (InserirLogVenda(lj, dt, dataPicker, cx, nfce))
                            {
                                mysqlConnect.SglinxClose();
                                connectionMysql = new MySqlConnection(mysqlConnect._connection);
                                connectionMysql.Open();
                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG0{lj}CFE{dt2} WHERE NUM_CFE = {nfce} ";

                                try
                                {
                                    MySqlCommand commandSql = connectionMysql.CreateCommand();
                                    commandSql.CommandText = sql;
                                    MySqlDataReader reader = commandSql.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        rv.Add(reader["rv"].ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                                if (InserirLogFin(lj, dt, rv[0]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 3)
                        {
                            if (InserirLogVenda(lj, dt, dataPicker, cx, nfce))
                            {
                                mysqlConnect.SglinxClose();
                                connectionMysql = new MySqlConnection(mysqlConnect._connection);
                                connectionMysql.Open();
                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG{lj}CFE{dt2} WHERE NUM_CFE = {nfce} ";
                                try
                                {
                                    MySqlCommand commandSql = connectionMysql.CreateCommand();
                                    commandSql.CommandText = sql;
                                    MySqlDataReader reader = commandSql.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        rv.Add(reader["rv"].ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                                if (InserirLogFin(lj, dt, rv[0]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:" + ex);
                        return false;
                    }
                    finally
                    {
                        connectionMysql.Close();
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }
        }
        public bool InserirSequenciaLogVendaFin(string lj, string dt, string dataPicker, string cx, string nfceIni, string nfceFin)
        {
            try
            {
                if (mysqlConnect.SglinxConnect())
                {
                    string dt2 = geral.InverterData(dt);
                    try
                    {
                        if (lj.ToCharArray().Length == 1)
                        {
                            if (InserirSequenciaLogVenda(lj, dt, dataPicker, cx, nfceIni, nfceFin))
                            {
                                mysqlConnect.SglinxClose();
                                connectionMysql = new MySqlConnection(mysqlConnect._connection);
                                connectionMysql.Open();

                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG00{lj}CFE{dt2} WHERE NUM_CFE in({nfceIni},{nfceFin})";

                                MySqlCommand commandSql = connectionMysql.CreateCommand();
                                commandSql.CommandText = sql;
                                MySqlDataReader reader = commandSql.ExecuteReader();

                                while (reader.Read())
                                {
                                    rv.Add(reader["rv"].ToString());
                                }

                                if (InserirSequenciaLogFin(lj, dt, rv[0], rv[1]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 2)
                        {
                            if (InserirSequenciaLogVenda(lj, dt, dataPicker, cx, nfceIni, nfceFin))
                            {
                                mysqlConnect.SglinxClose();
                                connectionMysql = new MySqlConnection(mysqlConnect._connection);
                                connectionMysql.Open();

                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG0{lj}CFE{dt2} WHERE NUM_CFE in({nfceIni},{nfceFin})";

                                MySqlCommand commandSql = connectionMysql.CreateCommand();
                                commandSql.CommandText = sql;
                                MySqlDataReader reader = commandSql.ExecuteReader();

                                while (reader.Read())
                                {
                                    rv.Add(reader["rv"].ToString());
                                }

                                if (InserirSequenciaLogFin(lj, dt, rv[0], rv[1]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (lj.ToCharArray().Length == 3)
                        {
                            if (InserirSequenciaLogVenda(lj,dt,dataPicker,cx,nfceIni,nfceFin))
                            {

                                mysqlConnect.SglinxClose();
                                connectionMysql = new MySqlConnection(mysqlConnect._connection);
                                connectionMysql.Open();
                                List<string> rv = new List<string>();
                                string sql = $"SELECT RV FROM LOG{lj}CFE{dt2} WHERE NUM_CFE in({nfceIni},{nfceFin})";

                                MySqlCommand commandSql = connectionMysql.CreateCommand();
                                commandSql.CommandText = sql;
                                MySqlDataReader reader = commandSql.ExecuteReader();

                                while (reader.Read())
                                {
                                    rv.Add(reader["rv"].ToString());
                                }

                                if (InserirSequenciaLogFin(lj, dt, rv[0], rv[1]))
                                {
                                    return true;
                                    

                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                           
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu uma exceção ao rodar o comando:" + ex);
                        return false;
                    }
                    finally
                    {
                        connectionMysql.Close();
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao conectar ao banco de dados: " + ex);
                return false;
            }

        }

        #endregion
    }



}

