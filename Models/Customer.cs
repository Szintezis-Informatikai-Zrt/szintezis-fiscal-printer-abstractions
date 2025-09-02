namespace CronisNext.FiscalPrinter.Models;

/// <summary>
/// Represents customer information required for invoice generation and business-to-business transactions.
/// </summary>
/// <remarks>
/// Customer information is mandatory for simplified invoices and certain high-value transactions.
/// The information must comply with local business regulations and tax requirements. All address
/// components are used to generate properly formatted invoice headers that meet legal standards.
/// </remarks>
public class Customer
{
    /// <summary>
    /// Gets or sets the customer's tax reference number (tax identification number).
    /// </summary>
    /// <value>
    /// The tax identification number used for business transactions and VAT reporting.
    /// Should be 11 digits for valid Hungarian tax numbers, or empty for non-business customers.
    /// </value>
    /// <remarks>
    /// The tax reference number is validated for proper format and is required for business invoices.
    /// For simplified invoices, if an invalid tax number is provided, it will be included in the
    /// comment field instead of the structured tax number field.
    /// </remarks>
    public string TaxRefNum { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer's full name or business name.
    /// </summary>
    /// <value>
    /// The complete name of the customer, limited to 64 characters for printing compatibility.
    /// </value>
    /// <remarks>
    /// This field is required for all invoices and should contain the legally registered business name
    /// for companies or the full personal name for individual customers. The name appears prominently
    /// on the invoice header.
    /// </remarks>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postal code for the customer's address.
    /// </summary>
    /// <value>
    /// The postal code, limited to 16 characters for printing compatibility.
    /// </value>
    /// <remarks>
    /// The postal code is part of the complete address information required for invoices.
    /// It should follow the standard postal code format for the customer's country.
    /// </remarks>
    public string PostCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city name for the customer's address.
    /// </summary>
    /// <value>
    /// The city or municipality name, limited to 64 characters for printing compatibility.
    /// </value>
    /// <remarks>
    /// The city name is a required component of the customer address for invoice generation.
    /// It should be the official municipality name as used in postal addressing.
    /// </remarks>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street address for the customer.
    /// </summary>
    /// <value>
    /// The street name and any additional address details, limited to 64 characters.
    /// </value>
    /// <remarks>
    /// This field contains the primary street address information. Complex addresses may
    /// require additional details to be included in other address fields for complete
    /// address specification.
    /// </remarks>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the street type designation (e.g., "Street", "Avenue", "Boulevard").
    /// </summary>
    /// <value>
    /// The street type designation, limited to 32 characters for printing compatibility.
    /// </value>
    /// <remarks>
    /// Street type provides additional address clarification common in European addressing
    /// systems. Examples include "utca" (street), "út" (road), "tér" (square) in Hungarian
    /// addressing conventions.
    /// </remarks>
    public string StreetType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the house number and any additional building identifiers.
    /// </summary>
    /// <value>
    /// The house number and building details, limited to 32 characters.
    /// </value>
    /// <remarks>
    /// House number includes the building number and any additional identifiers such as
    /// apartment numbers, floor designations, or building designators needed for complete
    /// address identification.
    /// </remarks>
    public string HouseNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional comments or notes about the customer.
    /// </summary>
    /// <value>
    /// Free-form text for additional customer information or special instructions.
    /// </value>
    /// <remarks>
    /// The comment field can contain additional customer information, special delivery instructions,
    /// or tax number information that doesn't fit the standard format. This field appears on
    /// the printed invoice and can be used for operational notes.
    /// </remarks>
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Returns a formatted string representation of the customer information suitable for printing on invoices.
    /// </summary>
    /// <returns>
    /// A multi-line string containing all customer information formatted for invoice printing,
    /// with each address component on a separate line.
    /// </returns>
    /// <remarks>
    /// The string format follows standard invoice formatting conventions with tax number first,
    /// followed by name and complete address details. Empty fields are replaced with spaces
    /// to maintain consistent formatting alignment.
    /// </remarks>
    public override string ToString()
    {
        return $"{TaxRefNum}\n{EnsureNotEmpty(CustomerName)}\n{EnsureNotEmpty(PostCode)}\n{EnsureNotEmpty(City)}\n{EnsureNotEmpty(Address)}\n{StreetType}\n{HouseNumber}\n{Comment}";
    }

    /// <summary>
    /// Ensures that empty or null strings are replaced with a single space for consistent formatting.
    /// </summary>
    /// <param name="value">The string value to check and format</param>
    /// <returns>The original value if not empty, otherwise a single space character</returns>
    /// <remarks>
    /// This helper method maintains consistent spacing in printed invoices by ensuring that
    /// empty address fields don't collapse, which could affect the visual layout and
    /// alignment of the invoice format.
    /// </remarks>
    private static string EnsureNotEmpty(string value)
    {
        return string.IsNullOrEmpty(value) ? " " : value;
    }
}
