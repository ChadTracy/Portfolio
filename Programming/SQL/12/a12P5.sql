--Chad Tracy 
--Assignment 12
--Part 5

--5 What is the SQL command to list the total sales by customer and by product, with subtotals by customer and a
--grand total for all product sales? Figure P13.5 shows the abbreviated results of the query.
select CUS_CODE, P_CODE, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWDAYSALESFACT
GROUP BY ROLLUP(CUS_CODE, P_CODE)

--6. What is the SQL command to list the total sales by customer, month, and product, with subtotals by customer
--and by month and a grand total for all product sales? Figure P13.6 shows the abbreviated results of the query.
select CUS_CODE, TM_Month, P_Code, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWDAYSALESFACT D INNER JOIN DWTIME T
ON D.TM_ID = T.TM_ID
group by ROLLUP(CUS_CODE, TM_MONTH, P_CODE)

--7. What is the SQL command to list the total sales by region and customer, with subtotals by region and a grand
--total for all sales? Figure P13.7 shows the result of the query.
SELECT R.REG_ID, C.CUS_CODE, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWREGION R INNER JOIN DWCUSTOMER C
ON R.REG_ID = C.REG_ID INNER JOIN DWDAYSALESFACT
ON C.CUS_CODE = DWDAYSALESFACT.CUS_CODE
GROUP BY ROLLUP(R.REG_ID, C.CUS_CODE)

--8. What is the SQL command to list the total sales by month and product category, with subtotals by month and a
--grand total for all sales? Figure P13.8 shows the result of the query.
SELECT TM_MONTH, P_Category, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWTIME T INNER JOIN DWDAYSALESFACT D
ON T.TM_ID = D.TM_ID INNER JOIN DWPRODUCT
ON D.P_CODE = DWPRODUCT.P_CODE
GROUP BY ROLLUP (T.TM_MONTH, P_CATEGORY)

--10. What is the SQL command to list the number of product sales (number of rows) and total sales by month and
-- category, with subtotals by month and product category and a grand total for all sales? Figure P13.10
--shows the result of the query.
SELECT TM_MONTH, P_Category, COUNT(SALE_UNITS) AS NUMPROD, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWTIME T INNER JOIN DWDAYSALESFACT D
ON T.TM_ID = D.TM_ID INNER JOIN DWPRODUCT
ON D.P_CODE = DWPRODUCT.P_CODE
GROUP BY ROLLUP(TM_MONTH, P_CATEGORY)

--12 Using the answer to Problem 10 as your base, what command would you need to generate the same output but
--with subtotals in all columns? (Hint: Use the CUBE command.) Figure P13.12 shows the result of the query.
SELECT TM_MONTH, P_Category, COUNT(*) AS NUMPROD, sum(SALE_UNITS * SALE_PRICE) AS TOTSALES
FROM DWTIME T INNER JOIN DWDAYSALESFACT D
ON T.TM_ID = D.TM_ID INNER JOIN DWPRODUCT
ON D.P_CODE = DWPRODUCT.P_CODE
GROUP BY CUBE(TM_MONTH, P_CATEGORY)
ORDER BY TM_MONTH