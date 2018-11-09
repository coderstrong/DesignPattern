# DesignPattern
Design Pattern basic implement

In the core project, we keep the entities and the repository interfaces or the database operation interfaces. The core project contains information about the domain entities and the database operations required on the domain entities. In an ideal scenario, the core project should not have any dependencies on external libraries. It must not have any business logic, database operation codes etc.

In short, the core project should contain:

Domain entities
Repository interfaces or database operations interfaces on domain entities
Domain-specific data annotations
The core project can NOT contain:

Any external libraries for database operations
Business logic
Database operations code
While creating the domain entities, we also need to make a decision on the restrictions on the domain entities properties, for example:

Whether a particular property is required or not. For instance, for a Product entity, the name of the product should be required property.
Whether a value of a particular property is in given range or not. For instance, for a Product entity, the price property should be in given range.
Whether the maximum length of a particular property should not be given value. For instance, for a Product entity, the name property value should be less than the maximum length.
There could be many such data annotations on the domain entities properties. There are two ways we can think about these data annotations:

As part of the domain entities
As part of the database operations logic
It is purely up to us how we see data annotations. If we consider them part of database operation then we can apply restrictions using database operation libraries API. We are going to use the Entity Framework for database operations in the Infrastructure project, so we can use Entity Framework Fluent API to annotate data.