# Currency Converter - Win Forms .Net8 - Eng Maged Ali

Project Title: Currency Converter - WinForms (.NET 8)

![rete](https://github.com/user-attachments/assets/31a55137-476b-45bd-9b65-e0c2a7680056)


This is a simple currency converter application built using WinForms in .NET 8. The application retrieves exchange rates for selected currencies from an external API and displays the conversion rates based on the USD. The application includes features like loading a list of currencies dynamically, selecting multiple currencies via checkboxes, and showing real-time exchange rates.

Key Features:
1. Dynamic Currency Loading: The list of available currencies is fetched from the `OpenExchangeRates` API, ensuring it’s always up-to-date.
2. Exchange Rate Display: Users can select multiple currencies from a dynamically populated list, and their exchange rates against USD are displayed in real-time.
3. Flow Layout with Checkboxes: The currency list is displayed as checkboxes in a FlowLayoutPanel, allowing users to select multiple currencies at once.
4. Custom Styling: Custom color schemes and button designs are used to make the application visually appealing, including rounded buttons.

Technical Stack:
- Platform: Windows Forms (WinForms) in .NET 8
- Programming Language: C#
- External Libraries: 
  - `Newtonsoft.Json` for JSON deserialization
  - `System.Net.Http` for making HTTP API calls
- API Used: 
  - `https://openexchangerates.org/api/currencies.json` (For fetching available currencies)
  - `https://openexchangerates.org/api/latest.json` (For fetching exchange rates)

How It Works:

1. Loading Currencies:
When the form loads, it makes an API call to fetch a list of currency codes and their full names. This is achieved through the `LoadCurrencies()` method, which sends an HTTP GET request to `https://openexchangerates.org/api/currencies.json`. The response is a JSON object that maps currency codes to their respective names.

- API Call Example:
  ```json
  {
    "AED": "United Arab Emirates Dirham",
    "AFN": "Afghan Afghani",
    "ALL": "Albanian Lek",
    ...
  }
  ```
- The list is deserialized and each currency is displayed as a checkbox inside a `FlowLayoutPanel`.

2. Selecting Currencies:
The user can select one or more currencies from the list by checking the boxes. The selected currencies' exchange rates will be displayed when the user clicks the "Get Exchange Rates" button.

3. Fetching Exchange Rates:
Once the currencies are selected, an API call is made to `https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID&base=USD`. The response contains the exchange rates of various currencies relative to USD.

- API Response Example:
  ```json
  {
    "disclaimer": "Usage subject to terms: https://openexchangerates.org/terms",
    "license": "https://openexchangerates.org/license",
    "timestamp": 1391235586,
    "base": "USD",
    "rates": {
      "AED": 3.672538,
      "AFN": 57.8936,
      "ALL": 104.8261,
      "AMD": 409.0296,
      ...
    }
  }
  ```
- The rates for the selected currencies are extracted and displayed in a `RichTextBox`.

4. UI Customization:
- The form background is set to white to give a clean look.
- The `FlowLayoutPanel` has a background color of `#4FEDB5`, which is a vibrant green.
- A custom button with rounded edges is created using a `RoundedButton` class, with the same color scheme.
- The EGP (Egyptian Pound) checkbox is given a special green font color to highlight its importance.

Code Breakdown:

1. Form1 Constructor and Initialization
```csharp
public Form1()
{
    InitializeComponent();
    LoadCurrencies(); // Load currencies when the form is initialized
}
```
- Initializes the form and immediately loads the currencies from the API.

2. Loading Currencies from API
```csharp
private async void LoadCurrencies()
{
    string response = await GetApiResponseAsync(ApiUrl);
    if (!string.IsNullOrEmpty(response))
    {
        var currencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
        // Create CheckBox for EGP (Egyptian Pound) first
        // Create CheckBoxes for the other currencies
    }
}
```
- Fetches the list of currencies and dynamically creates checkboxes for each currency.
  
3. Fetching Exchange Rates
```csharp
private async void button1_Click(object sender, EventArgs e)
{
    List<string> selectedCurrencies = new List<string>();
    foreach (Control control in flpCurrencies.Controls)
    {
        if (control is CheckBox checkBox && checkBox.Checked)
        {
            selectedCurrencies.Add(checkBox.Tag.ToString());
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
```
- When the button is clicked, it checks for selected currencies and makes an API call to fetch exchange rates.

4. API Response Helper Method
```csharp
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
```
- Helper function to make asynchronous API requests and handle errors.

Future Enhancements:
1. Error Handling: Add better error handling for API failures, such as retry logic or offline mode.
2. Cache Mechanism: Cache the list of currencies locally to avoid frequent API calls.
3. Performance Improvements: Optimize the UI for large lists of currencies and improve performance for multiple selections.
4. Multi-Currency Conversion: Expand the functionality to allow conversions between currencies other than USD.
5. UI Enhancements: Consider adding charts or graphs to visualize exchange rate trends.

