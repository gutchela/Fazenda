using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class VacinaModel
    {
        public int IdVacina { get; set; }       
        public string Descricao { get; set; }       
        public string Data { get; set; }
     
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public VacinaModel()
        {

        }

        //Recebe o contexto para acesso às variáveis de sessão.
        public VacinaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<VacinaModel> ListaVacina()
        {

            List<VacinaModel> lista = new List<VacinaModel>();
            VacinaModel item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT IdVacina, Descricao, Data FROM Vacina";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VacinaModel();
                item.IdVacina = int.Parse(dt.Rows[i]["IDVacina"].ToString());
                item.Descricao = dt.Rows[i]["Descricao"].ToString();
                item.Data = dt.Rows[i]["Data"].ToString();
                          
                lista.Add(item);


            }
            return lista;

            
        }
        public void Insert()
        {
            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO VACINA (IDVACINA, DESCRICAO, DATA) VALUES ('{IdVacina}','{Descricao}','{Data}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
        /*
        public void Excluir(int id_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM CONTA WHERE ID=" + id_conta);
        }

    */
    }
}

