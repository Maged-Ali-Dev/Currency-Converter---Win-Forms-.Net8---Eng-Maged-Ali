using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter___Win_Forms_.Net8___Eng_Maged_Ali
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://openexchangerates.org/api/currencies.json"; // API for currency codes
        private const string LatestRatesUrl = "https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID&base=USD";

        public Form1()
        {
            InitializeComponent();
            LoadCurrencies(); // Load currencies when the form is initialized

        }

        private async void LoadCurrencies()
        {
            string response = await GetApiResponseAsync(ApiUrl);
            if (!string.IsNullOrEmpty(response))
            {
                var currencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

                // Create a CheckBox for EGP first
                if (currencies.ContainsKey("EGP"))
                {
                    CheckBox egpCheckBox = new CheckBox
                    {
                        Text = "EGP (Egyptian Pound)",
                        Tag = "EGP", // Store currency code in the Tag property
                       // ForeColor = System.Drawing.Color.Green // Set text color to green for EGP
                    };
                    flpCurrencies.Controls.Add(egpCheckBox); // Add EGP CheckBox to FlowLayoutPanel
                }

                // Create CheckBoxes for the other currencies
                foreach (var currency in currencies)
                {
                    // Skip EGP since it's already added
                    if (currency.Key == "EGP") continue;

                    CheckBox checkBox = new CheckBox
                    {
                        Text = currency.Key + " (" + currency.Value + ")",
                        Tag = currency.Key // Store currency code in the Tag property
                    };
                    flpCurrencies.Controls.Add(checkBox); // Add CheckBox to FlowLayoutPanel
                }
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedCurrencies = new List<string>();
            foreach (Control control in flpCurrencies.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    selectedCurrencies.Add(checkBox.Tag.ToString()); // Get currency code from Tag
                }
            }

            if (selectedCurrencies.Count == 0)
            {
                MessageBox.Show("Please select at least one currency.");
                return;
            }

            string response = await GetApiResponseAsync(LatestRatesUrl);
            if (!string.IsNullOrEmpty(response))
            {
                string exchangeRates = GetExchangeRatesForSelectedCurrencies(response, selectedCurrencies);
                richTextBox1.Text = exchangeRates;
            }
        }

        private async Task<string> GetApiResponseAsync(string url)
        {
            try
            {
                var response = await client.GetStringAsync(url);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return string.Empty;
            }
        }

        private string GetExchangeRatesForSelectedCurrencies(string jsonResponse, List<string> currencies)
        {
            try
            {
                dynamic json = JsonConvert.DeserializeObject(jsonResponse);
                var rates = json.rates;
                string result = "";

                foreach (var currency in currencies)
                {
                    if (rates[currency] != null)
                    {
                        result += $"1 USD = {rates[currency]} {currency}\n";
                    }
                }

                return result.Length > 0 ? result : "No valid currencies found.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing response: {ex.Message}");
            }
            return null; // Return null if error occurs
        }


    }
}
