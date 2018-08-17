using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object sender, EventArgs args)
        {
            //todo lógica do programa
            //toto validações

            String cep = (CEP.Text + "").Trim();

            try
            {

                if (isValidCEP(cep))
                {
                    Endereco end = ViaCEPServico.BuscarEndercoViaCEP(cep);

                    Resultado.Text = string.Format("Endereço: {0}, {1}, {2}", end.localidade, end.uf, end.logradouro);
                }

            } catch (Exception ex)
            {




            }
        }
        private bool isValidCEP(String cep)
        {

            if (cep.Length != 8)
            {
                CEP.Focus();
                DisplayAlert("ERRO", "CEP inválido, deve conter 8 caracteres !", "OK");
                return false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                CEP.Focus();
                DisplayAlert("ERRO", "CEP inválido, deve conter 8 caracteres numéricos !", "OK");
                return false;

            }


            return true;



        }
    }
}
