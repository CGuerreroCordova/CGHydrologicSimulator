
# Jogging API REST Server


1. [Register a new user](#register-a-new-user)
2. [Get list of users and roles by a manager](#get-list-of-users-and-roles-by-a-manager)
3. [Get list of users and roles by an admin](#Get-list-of-users-and-roles-by-an-admin)
4. [](#)
5. [](#)
6. [](#)
7. [](#)
8. [](#)
9. [](#)
10. [](#)

## 
## Login to Jogging server
## Post an entry of jogging 
## Get the list of entries of jogging of an user 
## Delete an entry of jogging 
## Get an entry of jogging
## Modify an entry of jogging
## Get the list of reports of jogging of an user
## Get an specific report of jogging



## Register a new user

  Register an user into Jogging server

* **URL**

  /users

* **Method:**

  `POST`

*  **URL Params**

   **Required:**

   `username=[string]`   
   `password=[string]`

* **Data Params**

  None

* **Success Response:**

  * **Code:** 201 <br />
    **Content:**
    ```json
    { "Result" :  "User [username] created."}
    ```       


* **Error Response:**

  * **Code:** 400 HTTP BAD REQUEST <br />
    **Content:**
     ```json
     { "error" : "User name [username] not available." }
     ``` 

* **Sample Call:**

  ```/users?username=newuser&password=newpassword```

## Get list of users and roles by a manager

  Required the requester logged has a Manager role 

* **URL**

  /users

* **Method:**

  `GET`

*  **URL Params**

   None       

* **Data Params**

    None
  
 * **Headers Params**

   `key="token", value=[string:token provided]`
   
   Token provided with login, with permission of Manager

* **Success Response:**

  * **Code:** 200 OK <br />
    **Content example:** 



# CGHydrologicSimulator:

Hydrologic Simulator to reproduce how water flows on a digital elevation model (DEM).
This project corresponds with the implementation of thesis work to get title of M.Sc. in Computer Sciences.

## Description of Thesis work:

This is an implementacion on C# about a **Hidrologic Simulator** based on Lisflood-FP model following ESA Software-Engineering Standards.

## This work was presented then in

* Nation Congress of Water, Argentina: CONGRESO NACIONAL DEL AGUA – CONAGUA 2013
* XX Congress on Methods Numeric and Applications ENIEF 2013

Also was nominated for the innovation prize in the **Israel Innovation Awards 2017**.

To see a detailed explanation of this work a pdf report can be found at: [Thesis Report (spanish)](https://github.com/CGuerreroCordova/CGHydrologicSimulator/blob/master/doc/CGuerrero-Tesis-HydroSim.pdf)
