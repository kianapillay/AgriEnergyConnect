AgriEnergy Application - README
Overview
The AgriEnergy application is a prototype designed to manage farmer profiles and their product listings. This system aims to streamline product listings for farmers and allow employees to manage farmer profiles and view products. The system features a secure authentication mechanism to protect user data and ensure role-based access to functionalities.

The application uses SQL Server Management Studio (SSMS) for database management and stores relational data regarding farmers and their products. The system supports two types of users:

Farmers: Can add products to their profiles and view their own product listings.

Employees: Can add new farmer profiles, view all products from specific farmers, and use filters for product searching.

Getting Started
Prerequisites
To set up and run the AgriEnergy prototype locally, ensure you have the following:

Microsoft Visual Studio 2019 or later (for building and running the application).

.NET Core 3.1 or higher.

SQL Server Management Studio (SSMS) for managing the database.

Installation Steps
Clone the Repository: Download the source code or clone the repository to your local machine.

Open the Solution: Launch Visual Studio and open the solution file.

Configure Connection Strings: In the appsettings.json file, configure the connection strings to connect to your local or remote SQL Server database.

Set up Database:

Run SQL Server Management Studio (SSMS) and execute the provided SQL scripts to create the necessary database schema.

The schema includes tables for Farmers, Products, and Users.

Build and Run the Solution: Once the database is set up, build the solution and run the application in Visual Studio.

Upon launch, you will be presented with a secure login screen. Farmers and employees can log in with their respective credentials.

Database Information
The system uses SQL Server to manage the following data:

Farmer Table: Stores information about the farmer such as name, contact details, and profile information.

Product Table: Stores the products added by farmers, including details like product name, description, image, price, and production date.

User Table: Stores login information for all users (farmers and employees) and their roles (Farmer or Employee).

System Features
User Roles and Authentication
The application supports two types of user roles:

Farmer:

Farmers can add products to their profile, including product name, description, image, price, and production date.

Farmers can view their own products listed in their profile.

Employee:

Employees can add new farmer profiles by entering necessary details.

Employees can view all products from any farmer, filterable by product categories, production dates, etc.

Employees can search products using filters such as date and product category.

The system employs secure login functionality with authentication mechanisms to protect user data. Only users with valid credentials and proper roles can access the respective functionalities.

Functional Features for Farmers
Add Products: Farmers can add new products with the following details:

Product name

Product description

Product image

Product price

Production date

View Products: Farmers can view the products they've added, including details like name, description, price, and production date.

Functional Features for Employees
Add Farmer Profiles: Employees can create new farmer profiles by entering the farmer’s necessary details, such as name, contact info, etc.

View and Filter Products: Employees can:

View all products listed by any farmer.

Filter the products based on criteria like product category and production date.

Search Products: Employees can search for products using a set of filters (e.g., by date, category, etc.).

How to Use the Application
For Farmers:
Login: Use your credentials to log in as a Farmer.

Add a Product:

Navigate to the "Add Product" page.

Fill in the product details (name, description, image, price, production date).

Submit to add the product to your profile.

View Products:

After login, navigate to the "My Products" page to see a list of products you've added.

For Employees:
Login: Use your credentials to log in as an Employee.

Add a Farmer Profile:

Navigate to the "Add Farmer" section.

Fill in the necessary details to create a new farmer profile.

View and Filter Products:

Go to the "View Products" page to see all the products listed by farmers.

Use available filters (e.g., by date, category) to search and organize products.

Features
Functional Requirements
Farmer Product Management: Farmers can add, edit, and view products.

Employee Role Management: Employees can add new farmers and filter products based on multiple criteria.

Role-Based Access: The application ensures that only authenticated users with the appropriate role (Farmer or Employee) can access specific features.

Non-Functional Requirements
Performance: The system responds quickly with minimal latency.

Reliability: The application is designed to be stable and dependable.

Usability: The interface is simple and easy to use, ensuring that both technical and non-technical users can interact with the system effectively.

Security: The application uses secure authentication to ensure role-based access to functionalities.

Architecture
The AgriEnergy application follows a standard ASP.NET MVC architecture.

ASP.NET MVC: Handles the user interface and business logic.

SQL Server: Stores and manages the relational data for farmers, products, and users.

Contributions
We welcome contributions to the AgriEnergy project! To contribute:

Report any issues or bugs via GitHub.

Propose new features or improvements via GitHub discussions.

Submit pull requests following the project’s coding guidelines.

FAQ
Q: How do I add a product as a farmer?
A: After logging in as a farmer, navigate to the "Add Product" page, fill in the product details, and submit.

Q: Can I view products from other farmers as an employee?
A: Yes, employees can view products from all farmers and filter the products by criteria like date or category.

Q: How do I add a new farmer profile?
A: Employees can add new farmer profiles by logging in and navigating to the "Add Farmer" section.

Q: Can I edit my product details as a farmer?
A: Yes, a product can be edited by a farmer. 

Contact and Support
For further assistance, please contact:

Email: st10258543@vcconnect.edu.za

License
This project is licensed under the MIT License.

Authors
The AgriEnergy application was developed by Kiana Pillay.

GitHub Link
GitHub Repository

Default User Login Details
Farmer

Username: farmer@example.com

Password: farmer123

Employee

Username: employee@example.com

Password: employee123

References
Microsoft ASP.NET MVC Documentation

SQL Server Documentation
