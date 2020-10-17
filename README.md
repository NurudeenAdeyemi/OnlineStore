# OnlineStore
E-commerce is fast gaining ground as an accepted and used business paradigm. Many people prefer online shopping because of its different kinds of convenience. However, there are limited online agricultural food basket shopping stores compared to general E-commerce stores, which could be due to high perishability of agricultural products. Nowadays, people are so busy that they have no time to go to markets or those big shopping malls and buy the things they want and this was the problem primarily intended for online shopping to solve.
This project will provides a management system, which puts the owner in control of the products offer and sales online. It takes into account what it is that customers really needs and makes shopping easy and convenient for the customers as well as deliveries to their doorsteps. Everything from adding and updating products through receiving orders, printing packing slips can be handled right from the computer/mobile.

Scope 
The main scope of this project is to develop a general-purpose e-commerce store where agricultural products like fruit and vegetables can be bought from the comfort of home through the Internet. Specifically, the software has options to deal with all types of features, including
ADMIN 
•	Manage user: The administrator can add admin, delete admin, view customer, block user and manage every user’s information of the system
•	Manage products: The administrator can add product, delete product, view product and display products and services in the store.
•	Manage orders: The administrator can view orders and delete orders. Admin can ship order to user based on order placed by sending confirmation mail.
-The system must identify the login of the admin. 
-Admin account should be secured so that only owner of the shop can access that account 

USER
Registration of new user: A new user will have to register in the system by providing essential details in order to purchase the products in the system. 
-System must be able to verify and validate information. 
- System must encrypt the password of the customer to provide security. 

User login: This feature used by the user to login into system. A user must login with his user name and password to the system after registration. If they are invalid, the user will not be allowed to access the system. 

Purchasing an item: The user can add the desired product into his cart by clicking ‘Add to cart’ option on the product. He can view his cart by clicking on the cart button. All products added by cart can be viewed in the cart. User can remove an item from the cart by clicking remove. At checkout time, the items in the shopping cart will be presented as an order. At that time, more information will be needed to complete the transaction. Usually, the customer will be asked to fill or select a billing address, a shipping address, a shipping option, and payment information such as credit card number. An e-mail notification is sent to the customer as soon as the order is placed. 
- System must ensure that, only a registered customer can purchase items. 

 
 
Use case diagram of the Online Shopping Website
SYSTEM ARCHITECTURE
The System Architecture shows the overall view of the components of the system to be developed. 
1.	Online shopping: Anyone can view Online Shopping portal and available products, but every user must login by his/her Username and password in order to purchase or order products. Unregistered members can register by navigating to registration page. Only Admin will have access to modify roles, by default developer can only be an ‘Admin’. Once user register site, his default role will be ‘User’.
2.	Payment: Use of credit card or debit card to make payments, e.g. PayPal Payment Security for Customers.
3.	Product delivery: Once a payment has been accepted, the product is shipped to the customer's address.

