using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace diplomchik
{
    public partial class pokazanie : Form
    {
        private Dictionary<string, double> tariffRates = new Dictionary<string, double>();


        public pokazanie()
        {
            InitializeComponent();
            InitializeTariffRates();
        }
        private void InitializeTariffRates()
        {
            // Добавьте тарифные ставки для разных видов услуг
            tariffRates.Add("Г.Вода", 12);
            tariffRates.Add("Х.Вода", 9);
            tariffRates.Add("Газ", 4);
            tariffRates.Add("Электричество", 7);
            
            // и т.д.
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string selectedService = guna2ComboBox1.SelectedItem?.ToString();
            if (selectedService != null && tariffRates.ContainsKey(selectedService))
            {
                // Получение начальных и конечных показаний счетчика от пользователя
                int startReading = Convert.ToInt32(guna2TextBox1.Text);
                int endReading = Convert.ToInt32(guna2TextBox2.Text);

                // Вычисление разницы между начальными и конечными показаниями счетчика
                int consumption = endReading - startReading;

                // Получение тарифной ставки для выбранного вида услуги
                double tariffRate = tariffRates[selectedService];

                // Расчет суммы к оплате
                double totalPayment = consumption * tariffRate;

                // Вывод результата пользователю
                MessageBox.Show($"К оплате за {selectedService}: {totalPayment} рублей");
            }
            else
            {
                MessageBox.Show("Выберите вид услуги и укажите корректные показания счетчика.");
            }
        }
    }

       
        

        }
    

        
    



