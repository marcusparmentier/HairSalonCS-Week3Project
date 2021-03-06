Word Counter

#### A MVC app with a database for a Hair Salon to keep track of their stylists and clients. 10/31/17

#### By **Marcus Parmentier**

## Description

A MVC app created with C Sharp and use of Razor and .NET framework with a database focusing on creating objects with a custom class and constructor, using RESTful route conventions using HttpGet and HttpPost, and routes to specific instance of the object. Also with a focus on BDD, use of MS Testing, and using MySQL databases.


## Setup/Installation Requirements

* Clone project from GitHub
* Have .NET Core 1.1.4 downloaded
* Restore and run project while in the project in your terminal



* Database setup
  * > CREATE DATABASE marcus_parmentier;
  * > USE marcus_parmentier;
  * > CREATE TABLE stylists (id serial PRIMARY KEY, employee VARCHAR(255), details VARCHAR(255));
  * > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), notes VARCHAR(255, stylist_id INT);

  * Repeat Instructions above except new database name is "marcus_parmentier_test"

## Known Bugs

* N/A

## Technologies Used

* C Sharp
 * .Net Core
 * MySQL database
 * Razor

## Support and contact details

_Email me at marcusjparmentier@gmail.com with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Marcus Parmentier}_**
