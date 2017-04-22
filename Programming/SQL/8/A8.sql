-- Chad Tracy
-- CIS 310-01
-- Assignment 8

-- 72
SELECT Movie_Title, Movie_Year, Movie_Genre
FROM MOVIE
-- 73
SELECT Movie_Year, Movie_Title, Movie_Cost
FROM MOVIE
ORDER BY Movie_Year DESC
--74
SELECT Movie_Title, Movie_Year, Movie_Genre
FROM MOVIE
ORDER BY Movie_Genre, Movie_Year DESC
--75
SELECT Movie_Num, Movie_Title, Price_Code
FROM MOVIE
WHERE Movie_Title LIKE 'r%'
--76
SELECT Movie_Title, Movie_Year, Movie_Cost
FROM MOVIE
WHERE Movie_Title LIKE '%hope%'
--77
SELECT Movie_Title, Movie_Year, Movie_Genre
FROM MOVIE
WHERE Movie_Genre = 'ACTION'
--78
SELECT Movie_Num, Movie_Title, Movie_Cost
FROM MOVIE
WHERE Movie_Cost > 40
--79
SELECT Movie_Num, Movie_Title, Movie_Cost, Movie_Genre
FROM MOVIE
WHERE Movie_Genre = 'ACTION' OR Movie_Genre = 'COMEDY' AND Movie_Cost < 50
ORDER BY Movie_Genre
--80
SELECT Movie_Num, CONCAT(CONCAT( Movie_Title , Movie_Year  ),Movie_Genre) 'Movie Description'
FROM MOVIE
--81
SELECT Movie_Genre, COUNT(*) 'Number of Movies'
FROM MOVIE
GROUP BY Movie_Genre
--82
SELECT AVG(Movie_Cost) 'Average Movie Cost'
FROM MOVIE
--83
SELECT Movie_Genre, AVG(Movie_Cost) 'Average Movie Cost'
FROM MOVIE 
GROUP BY Movie_Genre
--84
SELECT Movie_Title, Movie_Genre, Price_Description, Price_RentFee
FROM MOVIE
INNER JOIN PRICE
ON MOVIE.Price_Code = PRICE.Price_Code
WHERE PRICE.Price_Code IS NOT NULL
--85
SELECT Movie_Genre, AVG(Price_RentFee) 'Average Rental Fee'
FROM MOVIE, PRICE
WHERE Movie_Cost IS NOT NULL
GROUP BY Movie_Genre
--86
SELECT Movie_Title, Movie_Year, (Movie_Cost/Price_RentFee) 'Breakeven Rentals'
FROM MOVIE, PRICE
WHERE MOVIE.Price_Code = PRICE.Price_Code 
AND Movie_Cost IS NOT NULL
--87
SELECT Movie_Title, Movie_Year
FROM MOVIE
WHERE Price_Code IS NOT NULL
--88
SELECT Movie_Title, Movie_Year, Movie_Cost
FROM MOVIE
WHERE Movie_Cost > 44.99 AND Movie_Cost < 49.99
--89
SELECT Movie_Title, Movie_Year, Price_Description, Price_RentFee, Movie_Genre
FROM MOVIE, PRICE
WHERE MOVIE.Price_Code = PRICE.Price_Code
 AND Movie_Genre IN( 'FAMILY', 'COMEDY', 'DRAMA') 

 --90
 SELECT MOVIE.Movie_Num, Movie_Title, Movie_Year
 FROM MOVIE, VIDEO
 WHERE VIDEO.Movie_Num = MOVIE.Movie_Num
 --91
 SELECT MEMBERSHIP.Mem_Num, Mem_FName, Mem_LName, Mem_Balance
 FROM MEMBERSHIP, RENTAL
 WHERE MEMBERSHIP.Mem_Num = RENTAL.Mem_Num 
 --92
 SELECT MIN(Mem_Balance) 'Minimum Balance',
  MAX(Mem_Balance) 'Maximum Balance', 
 AVG(Mem_Balance) 'Average Balance'
 FROM MEMBERSHIP, RENTAL
 WHERE MEMBERSHIP.Mem_Num = RENTAL.Mem_Num
 AND RENTAL.Mem_Num IS NOT NULL
 --93
 SELECT CONCAT(Mem_FName,' ',Mem_LName) 'Membership Name',
 CONCAT(CONCAT(Mem_Street,' ', Mem_City),CONCAT(' ', Mem_State,' ', Mem_Zip)) 'Membership Address'
 FROM MEMBERSHIP
 --94
 SELECT DETAILRENTAL.Rent_Num, Rent_Date, Vid_Num, Movie_Title, Detail_DueDate, Detail_ReturnDate
 FROM MOVIE, DETAILRENTAL, RENTAL
 WHERE  RENTAL.Rent_Num = DETAILRENTAL.Rent_Num
 AND Detail_ReturnDate > Detail_DueDate
 ORDER BY Rent_Num, Movie_Title
 --95
 SELECT DETAILRENTAL.Rent_Num, Rent_Date, DETAILRENTAL.Vid_Num, Movie_Title, Detail_DueDate, Detail_ReturnDate, Detail_Fee, Detail_ReturnDate - Detail_DueDate AS 'Days Past Due'
 FROM RENTAL, DETAILRENTAL, MOVIE, VIDEO
WHERE RENTAL.Rent_Num = DETAILRENTAL.Rent_Num AND VIDEO.Movie_Num = MOVIE.Movie_Num AND
VIDEO.Vid_Num = DETAILRENTAL.Vid_Num AND Detail_ReturnDate > Detail_DueDate
ORDER BY Rent_Num, Movie_Title
 --96
 SELECT DETAILRENTAL.Rent_Num, Rent_Date, Movie_Title, Detail_Fee
 FROM DETAILRENTAL, RENTAL, MOVIE, VIDEO
 WHERE RENTAL.Rent_Num = DETAILRENTAL.Rent_Num AND VIDEO.Movie_Num = MOVIE.Movie_Num AND
VIDEO.Vid_Num = DETAILRENTAL.Vid_Num AND Detail_ReturnDate <= Detail_DueDate
 --97
 SELECT MEMBERSHIP.Mem_Num, Mem_LName, Mem_FName, SUM(Detail_LateFee.Price_DailyLateFee) AS 'Rental Fee Revenue'
 FROM MEMBERSHIP, DETAILRENTAL, RENTAL
 WHERE DETAILRENTAL.RentNum = RENTAL.RentNum AND DETAILRENTAL.Vid_Num = VIDEO.Vid_Num
 GROUP BY MEMBERSHIP.MemNum, Mem_LName, Mem_FName
 --98
 SELECT Movie_Num, MOvie_Genre, AVG(Movie_Cost) AS 'Average Cost',
 MOVIE_COST, (MOVIE_COST - AVG(Movie_Cost))
 FROM MOVIE
 GROUP BY Movie_Genre



