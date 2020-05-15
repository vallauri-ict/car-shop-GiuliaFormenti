using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseInstructionDLL;

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungiVeicolo : Form
    {
        private int y = 0;
        BindingList<VenditaVeicoliDLLProject.Veicolo> bindingListaVeicoli;

        public FormDialogAggiungiVeicolo(BindingList<VenditaVeicoliDLLProject.Veicolo> bindingListaVeicoli)
        {
            InitializeComponent();
            this.bindingListaVeicoli = bindingListaVeicoli;
        }

        private void FormDialogAggiungiVeicolo_Load(object sender, EventArgs e)
        {
            this.cmbTipoVeicolo.SelectedIndex = 0;
            this.cmbColore.SelectedIndex = 0;
            y = lblMarcaSella.Top;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbTipoVeicolo.SelectedItem + " - " + txtMarca.Text + " - ");
            if (cmbTipoVeicolo.SelectedIndex == 0)
            {
                VenditaVeicoliDLLProject.Moto m = new VenditaVeicoliDLLProject.Moto(txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToInt32(nmrPotenza.Value), dtpImmatricolazione.Value, rdbNo.Checked? false : true, rdbNoZ.Checked? false : true, Convert.ToInt32(nmrKmPercorsi.Value), txtMarcaSella.Text);
                bindingListaVeicoli.Add(m);
                UtilsDatabase.AddNewCar("Moto", txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToInt32(nmrPotenza.Value), Convert.ToDateTime(dtpImmatricolazione.Value), rdbNo.Checked ? false : true, rdbNoZ.Checked ? false : true, Convert.ToInt32(nmrKmPercorsi.Value), Convert.ToInt32(nmrPrezzo.Value), txtMarcaSella.Text, 0);
                //UtilsDatabase.AddNewItem("Moto", txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToDouble(nmrPotenza.Value), Convert.ToDateTime(dtpImmatricolazione.Value), rdbNo.Checked?false:true, rdbNoZ.Checked?false:true, Convert.ToInt32(nmrKmPercorsi), Convert.ToDouble(nmrPrezzo), Convert.ToInt32(nmrNumAirbag), txtMarcaSella.Text);
            }
            else
            {
                VenditaVeicoliDLLProject.Auto a = new VenditaVeicoliDLLProject.Auto(txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToInt32(nmrPotenza.Value), dtpImmatricolazione.Value, rdbNo.Checked ? false : true, rdbNoZ.Checked ? true : false, Convert.ToInt32(nmrKmPercorsi.Value), Convert.ToInt32(nmrNumAirbag.Value));
                bindingListaVeicoli.Add(a);
                UtilsDatabase.AddNewCar("Auto", txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToInt32(nmrPotenza.Value), Convert.ToDateTime(dtpImmatricolazione.Value), rdbNo.Checked ? false : true, rdbNoZ.Checked ? false : true, Convert.ToInt32(nmrKmPercorsi.Value), Convert.ToInt32(nmrPrezzo.Value), "/", Convert.ToInt32(nmrNumAirbag.Value));
                //UtilsDatabase.AddNewItem("Auto", txtMarca.Text, txtModello.Text, cmbColore.SelectedItem.ToString(), Convert.ToInt32(nmrCilindrata.Value), Convert.ToDouble(nmrPotenza.Value), Convert.ToDateTime(dtpImmatricolazione.Value), rdbNo.Checked ? false : true, rdbNoZ.Checked ? false : true, Convert.ToInt32(nmrKmPercorsi), Convert.ToDouble(nmrPrezzo), Convert.ToInt32(nmrNumAirbag), txtMarcaSella.Text);
            }


            this.Close();
        }

        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoVeicolo.SelectedIndex == 0)
            {
                lblMarcaSella.Show();
                txtMarcaSella.Show();
                lblNumeroAir.Hide();
                nmrNumAirbag.Hide();
            }
            else
            {
                lblMarcaSella.Hide();
                txtMarcaSella.Hide();
                lblNumeroAir.Show();
                nmrNumAirbag.Show();
                lblNumeroAir.Top = y;
                nmrNumAirbag.Top = y;
            }
        }
    }
}
