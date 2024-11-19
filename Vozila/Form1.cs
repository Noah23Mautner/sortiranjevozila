using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vozila
{
    public partial class Form1 : Form
    {

        private List<Vozila> listaVozila = new List<Vozila>();
        public Form1()
        {
            InitializeComponent();
            // Dodaj opcije za sortiranje direktno u ComboBox
            comboBox1.Items.AddRange(new string[] { "Marka", "Model", "Godina proizvodnje", "Kilometraža" });

            // Postavi podrazumevani izbor
            comboBox1.SelectedIndex = 0;

            radioUzlazno.Checked = true;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarka.Text) ||
                            string.IsNullOrWhiteSpace(txtModel.Text) ||
                            !int.TryParse(txtGodinaProizvodnje.Text, out int godinaProizvodnje) ||
                            !int.TryParse(txtKilometraza.Text, out int kilometraza))
            {
                MessageBox.Show("Unesite ispravne podatke za vozilo!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kreiraj novo vozilo
            Vozila novoVozilo = new Vozila(
                txtMarka.Text,
                txtModel.Text,
                godinaProizvodnje,
                kilometraza
            );

            // Dodaj u listu
            listaVozila.Add(novoVozilo);

            // Prikaz u ListBox-u
            listbox.Items.Add(novoVozilo);

            // Očisti polja
            txtMarka.Clear();
            txtModel.Clear();
            txtGodinaProizvodnje.Clear();
            txtKilometraza.Clear();
        }

        private void btnSortiraj_Click(object sender, EventArgs e)
        {
            if (listaVozila.Count == 0)
            {
                MessageBox.Show("Lista vozila je prazna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IOrderedEnumerable<Vozila> sortiranaVozila;
            // Dohvati odabranu opciju iz ComboBox-a i sortiraj
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Marka":
                    sortiranaVozila = radioUzlazno.Checked
                        ? listaVozila.OrderBy(v => v.Marka)
                        : listaVozila.OrderByDescending(v => v.Marka);
                    break;

                case "Model":
                    sortiranaVozila = radioUzlazno.Checked
                        ? listaVozila.OrderBy(v => v.Model)
                        : listaVozila.OrderByDescending(v => v.Model);
                    break;

                case "Godina proizvodnje":
                    sortiranaVozila = radioUzlazno.Checked
                        ? listaVozila.OrderBy(v => v.GodinaProizvodmje)
                        : listaVozila.OrderByDescending(v => v.GodinaProizvodmje);
                    break;

                case "Kilometraža":
                    sortiranaVozila = radioUzlazno.Checked
                        ? listaVozila.OrderBy(v => v.Kilometraza)
                        : listaVozila.OrderByDescending(v => v.Kilometraza);
                    break;

                default:
                    MessageBox.Show("Nepoznata opcija!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }


            // Ispis sortirane liste u TextBox (txtSortirano)
            txtSortirano.Clear(); // Očisti prethodni sadržaj TextBox-a
            foreach (var vozilo in sortiranaVozila)
            {
                txtSortirano.AppendText(vozilo.ToString() + Environment.NewLine); // Dodaj sortirana vozila u TextBox
            }



        }
    }
}
