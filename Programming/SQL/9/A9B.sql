--CHAD TRACY
--CIS 310-01
--A9B
--DUE: 3/23/2016


--1
CREATE TABLE NONGAME
(ITEM_NUM CHAR (4) PRIMARY KEY NOT NULL,
DESCRIPTION CHAR (30),
ON_HAND DECIMAL(4,0),
CATEGORY CHAR(3),
PRICE DECIMAL(6,2));

--2
INSERT INTO NONGAME
VALUES
('CD33', 'Wood Block Set (48 Piece)', 36, 'TOY', 89.49);
INSERT INTO NONGAME
VALUES
('DL51', 'Classic Railway Set', 12, 'TOY', 107.95);
INSERT INTO NONGAME
VALUES
('DR67', 'Giant Star Brain Teaser', 24, 'PZL', 31.95);
INSERT INTO NONGAME
VALUES
('FD11', 'Rocking Horse', 8, 'TOY', 124.95);
INSERT INTO NONGAME
VALUES
('FH24', 'Puzzle Gift Set', 65, 'PZL', 38.95);
INSERT INTO NONGAME
VALUES
('KD34', 'Pentominoes Brain Teaser', 60, 'PZL', 14.95);
INSERT INTO NONGAME
VALUES
('MT03', 'Zauberkasten Brain Teaser', 45, 'PZL', 45.95);
INSERT INTO NONGAME
VALUES
('NL89', 'Wood Block Set (62 Piece)', 32, 'TOY', 119.75);
INSERT INTO NONGAME
VALUES
('TW35', 'Fire Engine', 30, 'TOY', 1128.95); 

--3
UPDATE NONGAME
SET DESCRIPTION = 'Classic Train Set'
WHERE ITEM_NUM = 'DL51'

--4
UPDATE NONGAME
SET PRICE = PRICE * 1.02
WHERE CATEGORY = 'TOY'

--5
INSERT INTO NONGAME
VALUES
('TL92', 'Dump Truck', 10, 'TOY', 59.95);

--6
DELETE 
FROM NONGAME
WHERE CATEGORY = 'PZL'

--7
UPDATE NONGAME
SET CATEGORY = NULL
WHERE ITEM_NUM = 'FD11'

--8
ALTER TABLE NONGAME
ADD ON_HAND_VALUE DECIMAL(7,2)

UPDATE NONGAME 
SET ON_HAND_VALUE = ON_HAND * PRICE

--9
ALTER TABLE NONGAME
ALTER COLUMN DESCRIPTION CHAR(40)

--10
DROP TABLE NONGAME

--11
ALTER TABLE NONGAME
DROP COLUMN ON_HAND_VALUE
--SOURCE: http://www.techonthenet.com/sql/tables/alter_table.php