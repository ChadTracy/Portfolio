--Chad Tracy
--CIS 310-01
--Assignment 11
--Due: 4/13/2016

--Access tables in database
SELECT *
FROM PET ..Animal

--1. List the products with a list price greater than the average list price of all products.
SELECT *
FROM PET.. Animal
WHERE ListPrice > (SELECT AVG(ListPrice) FROM PET .. Animal)

--2. Which merchandise items have an average sale price more than 50 percent higher than their average purchase cost?
SELECT *
FROM PET..OrderItem O INNER JOIN PET..SaleItem S
ON O.ItemID = S.ItemID
WHERE (SELECT AVG(Cost) FROM PET..OrderItem) > ((SELECT AVG(SalePrice) FROM PET..SaleItem) * 1.5)
ORDER BY SalePrice


--3. List the employees and their total merchandise sales expressed as a percentage of total merchandise sales for all employees.
SELECT EmployeeID, (SELECT Quantity/SUM(Quantity) * 100)
FROM PET..Sale S INNER JOIN PET..SaleItem I
ON S.SaleID = I.SaleID
ORDER BY EmployeeID

--4. On average, which supplier charges the highest shipping cost as a percent of the merchandise order total?
SELECT avg(ShippingCost) * 100 / sum(ShippingCost), SupplierID
FROM PET..MerchandiseOrder
GROUP BY SupplierID

--5. Which customer has given us the most total money for animals and merchandise?
SELECT sum(PET..SaleAnimal.SalePrice) + sum(PET..SaleItem.SalePrice) as Money_Given_By_ID
FROM PET..SaleAnimal  INNER JOIN PET..Sale 
ON PET..SaleAnimal.SaleID = PET..Sale.SaleID  
INNER JOIN PET..SaleItem 
ON PET..Sale.SaleID = PET..SaleItem.SaleID
group by CustomerID
order by Money_Given_By_ID desc

--6. Which customers who bought more than $100 in merchandise in May also spent more than $50 on merchandise in October?
create view V May as
select C.customerid, FirstName, LastName, SaleDate, SUM(SalePrice * Quantity) as 'Total', S.SaleID
FROM PET..Customer C INNER JOIN PET..Sale S
on C.CustomerID = S.CustomerID INNER JOIN PET..SaleItem SI
on SI.SaleID = S.SaleID INNER JOIN Pet..SaleAnimal SA
on SA.SaleID = S.SaleID
where SaleDate between '2004-05-01' and '2004-05-31'
GROUP BY SaleDate, C.CustomerID, FirstName, LastName, S.SaleID
having sum(SalePrice*Quantity) > 100

create view V October as
select C.customerid, FirstName, LastName, SaleDate, SUM(SalePrice * Quantity) as 'Total', S.SaleID
FROM PET..Customer C INNER JOIN PET..Sale S
on C.CustomerID = S.CustomerID INNER JOIN PET..SaleItem SI
on SI.SaleID = S.SaleID INNER JOIN Pet..SaleAnimal SA
on SA.SaleID = S.SaleID
where SaleDate between '2004-10-01' and '2004-10-31'
GROUP BY SaleDate, C.CustomerID, FirstName, LastName, S.SaleID
having sum(SalePrice * Quantity) > 50


--7. What was the net change in quantity on hand for premium canned dog food between January 1 and July 1?

SELECT (SELECT SUM(QuantityOnHand) 
FROM PET..Merchandise M INNER JOIN PET..SaleItem S
ON M.ItemID = S.ItemID INNER JOIN PET..Sale L
ON S.SaleID = L.SaleID
WHERE month(SaleDate) >= 1 and day(SaleDate) >= 1 and month(SaleDate) < 7)
-
(SELECT SUM(QuantityOnHand)
FROM PET..Merchandise M INNER JOIN PET..SaleItem S
ON M.ItemID = S.ItemID INNER JOIN PET..Sale L
ON S.SaleID = L.SaleID
WHERE month(SaleDate) >= 7 and day(SaleDate) >= 1) AS CHANGE_IN_PREMIUM_DOG_FOOD
FROM PET..Merchandise
WHERE Description = 'Dog Food-Can-Premium'

--8. Which merchandise items with a list price of more than $50 hand no sales July?
SELECT *
FROM PET..Merchandise M INNER JOIN PET..SaleItem S
ON M.ItemID = S.ItemID INNER JOIN PET..Sale L
ON S.SaleID = L.SaleID
WHERE M.ListPrice > 50 and (select month(L.SaleDate) where month(L.SaleDate) = 6) is null 
--9. Which merchandise items with more than 100 units on hand have not been ordered in 2004? 
SELECT *
FROM PET..Merchandise M INNER JOIN PET..SaleItem S
ON M.ItemID = S.ItemID INNER JOIN PET..Sale L
ON S.SaleID = L.SaleID
WHERE QuantityOnHand > 50 and (select year(L.SaleDate) where year(L.SaleDate) = 2004) is null
--10. Populate Table
CREATE TABLE CategoryB
(Category CHAR(10) PRIMARY KEY,
Low DECIMAL(3,0),
High DECIMAL (5,0))
INSERT INTO CategoryB
VALUES( 'Weak', 0, 200)
INSERT INTO CategoryB
VALUES('Good', 200, 800)
INSERT INTO CategoryB
VALUES('Best', 800, 10000)

--11.Generate the following results using the Category table you created in 10 
--and the results in Exercise 5 of total amount of money spent by each customer. 
select C.CustomerID, FirstName, LastName, Sum(SA.SalePrice) + sum(SI.SalePrice * Quantity) as GrandTotal, Category
from PET..Customer C inner join PET..Sale S
on C.CustomerID = S. CustomerID INNER JOIN PET..SaleItem SI
on SI.SaleID = S.SaleID inner join PET..SaleAnimal SA
on SA.SaleID = S.SaleID, CustomersCategory C
group by C.CustomerID, LastName, Category
order by TotalDesc



 --12. List all suppliers (animals and merchandise) who sold us items in June. Identify whether they sold use animals or merchandise.
 SELECT SupplierID, 'Merchandise' AS "Type" 
 FROM PET..MerchandiseOrder
 WHERE month(OrderDate) = 6
 UNION
 SELECT SupplierID, 'Animal' AS "Type"
 FROM PET..AnimalOrder
 WHERE month(OrderDate) = 6