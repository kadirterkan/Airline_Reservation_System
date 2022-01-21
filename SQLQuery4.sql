SET IDENTITY_INSERT Authority ON;

INSERT INTO Authority(ID,Creation_Date, Update_Date, User_Type_Id, Authority_Name)
VALUES(1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 2, 'ADD_FLIGHT');


INSERT INTO Authority(ID,Creation_Date, Update_Date, User_Type_Id, Authority_Name)
VALUES(1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 2, 'ADD_ROUTE');


INSERT INTO Authority(ID,Creation_Date, Update_Date, User_Type_Id, Authority_Name)
VALUES(1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 2, '');

INSERT INTO Authority(ID,Creation_Date, Update_Date, User_Type_Id, Authority_Name)
VALUES(1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 'BOOK_FLIGHT');