# Cloud-based LAPS

**⚠️ This is a work-in-progress and nowhere near ready for production use.**

This project is for implementing a client/server LAPS (Local Administrator Password Solution) that isn't reliant on an on-premises Active Directory infrastructure. One of the main issues for IT support staff to perform administrative tasks on Azure AD joined devices is not having the ability to have a local admin account readily available that isn't using a password that is well known across the board.

[Microsoft has LAPS](https://www.microsoft.com/en-us/download/details.aspx?id=46899), but that unfortunately requires a device to be joined to an on-premises Active Directory domain. This will be usable on any Windows-based device.

## Components

### In-development

- **Client**
  - For maintaining the local admin account and communicating with the cloud resources.
- **Server**
  - Utilizing Azure Functions for handling communication from clients to Azure Key Vault and Azure CosmosDB.

### Planned

- **Web App**
  - For technicians to get passwords for devices without directly interfacing with the Azure Key Vault in the Azure Portal.