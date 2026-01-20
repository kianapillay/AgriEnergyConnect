# AgriEnergyConnect

## Overview

The **AgriEnergy** application is a prototype designed to manage farmer profiles and their product listings.  
This system aims to streamline product listings for farmers and allow employees to manage farmer profiles and view products.  
The system features a secure authentication mechanism to protect user data and ensure role-based access to functionalities.

The application uses **SQL Server Management Studio (SSMS)** for database management and stores relational data regarding farmers and their products.

### User Types
- **Admin:** Can create employee profiles with employee details.
- **Farmers:** Can add products to their profiles and view their own product listings.  
- **Employees:** Can add new farmer profiles, view all products from specific farmers, and use filters for product searching.

---

## Getting Started

### Prerequisites

To set up and run the AgriEnergyConnect prototype locally, ensure you have the following:

- Microsoft Visual Studio 2019 or later (for building and running the application)
- .NET Core 3.1 or higher
- SQL Server Management Studio (SSMS) for managing the database

### Installation Steps

1. **Clone the Repository:**  
   Download the source code or clone the repository to your local machine.

2. **Open the Solution:**  
   Launch Visual Studio and open the solution file.

3. **Configure Connection Strings:**  
   In the `appsettings.json` file, configure the connection strings to connect to your local or remote SQL Server database.

4. **Set up Database:**  
   Run SQL Server Management Studio (SSMS) and execute the provided SQL scripts to create the necessary database schema.  
   The schema includes tables for Farmers, Products, and Users.

5. **Build and Run the Solution:**  
   Once the database is set up, build the solution and run the application in Visual Studio.  
   Upon launch, you will be presented with a secure login screen. Farmers and employees can log in with their respective credentials.

---

## Database Information

The system uses SQL Server to manage the following data:

- **Farmer Table:** Stores information about farmers such as name, contact details, and profile information.
- **Product Table:** Stores products added by farmers, including product name, description, image, price, and production date.
- **User Table:** Stores login information for all users (farmers and employees) and their roles (Farmer or Employee).

---

## System Features

### User Roles and Authentication

The application supports three types of user roles:

- **Admin:**  
  - Create employee profile with employee details
 
- **Farmer:**  
  - Add products to their profile (name, description, image, price, production date)  
  - View their own products listed in their profile

- **Employee:**  
  - Add new farmer profiles by entering necessary details  
  - View all products from any farmer  
  - Filter products by categories, production dates, etc.  
  - Search products using filters like date and category

The system employs secure login functionality to protect user data. Only users with valid credentials and proper roles can access the respective features.

---

### Functional Features for Admin

- **Create Employee:**  
    Admins can create employee profiles with employee details.

---

### Functional Features for Farmers

- **Add Products:**  
  Farmers can add new products with details such as name, description, image, price, and production date.

- **View Products:**  
  Farmers can view the products they've added, including all details.

---

### Functional Features for Employees

- **Add Farmer Profiles:**  
  Employees can create new farmer profiles by entering the necessary details.

- **View and Filter Products:**  
  Employees can view all products listed by farmers and filter/search products by date, category, and other criteria.

---

## How to Use the Application

### For Admin

1. **Login:** Use Admin credentials to log in as Admin.
2. **Create Employee:**
   - Create employee profile with employee details.
     
### For Farmers

1. **Login:** Use your credentials to log in as a Farmer.  
2. **Add a Product:**  
   - Navigate to the "Add Product" page.  
   - Fill in the product details and submit to add it to your profile.  
3. **View Products:**  
   - Navigate to the "My Products" page to see your product listings.

### For Employees

1. **Login:** Use your credentials to log in as an Employee.  
2. **Add a Farmer Profile:**  
   - Navigate to the "Add Farmer" section.  
   - Fill in the necessary details to create a new farmer profile.  
3. **View and Filter Products:**  
   - Go to the "View Products" page to see all products.  
   - Use available filters to search and organize products.

---

## Features

### Functional Requirements

- Admin Role Management: Admins can create Employee profiles.
- Farmer Product Management: Farmers can add, edit, and view products.  
- Employee Role Management: Employees can add new farmers and filter products.  
- Role-Based Access: Only authenticated users with appropriate roles can access specific features.

### Non-Functional Requirements

- Performance: The system responds quickly with minimal latency.  
- Reliability: Designed to be stable and dependable.  
- Usability: Simple and easy to use interface for all users.  
- Security: Secure authentication and role-based access.

---

## Architecture

- **ASP.NET MVC:** Handles the user interface and business logic.  
- **SQL Server:** Manages relational data for farmers, products, and users.

---

## Contributions

We welcome contributions to the AgriEnergy project!

- Report issues or bugs via GitHub issues.  
- Propose features or improvements via GitHub discussions.  
- Submit pull requests following the project’s coding guidelines.

---

## FAQ

**Q:** How do I add a product as a farmer?  
**A:** After logging in, go to the "Add Product" page, fill in details, and submit.

**Q:** Can I view products from other farmers as an employee?  
**A:** Yes, employees can view and filter products from all farmers.

**Q:** How do I add a new farmer profile?  
**A:** Employees can add new farmer profiles by navigating to the "Add Farmer" section.

**Q:** Can I edit my product details as a farmer?  
**A:** Yes, farmers can edit their products.

---

## Admin Credentials
Username(email): admin@gmail.com
Password: Admin123

---

## Contact and Support

For further assistance, please contact:  
**Email:** st10258543@vcconnect.edu.za

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Authors

The AgriEnergy application was developed by **Kiana Pillay**.

---

## GitHub Link

https://github.com/VCWVL/prog7311-poe-St10258543.git
