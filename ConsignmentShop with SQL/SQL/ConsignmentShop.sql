create table merchandise (MerchandiseID int not null, primary key(MerchandiseID));



alter table merchandise add Navn varchar(255);

alter table merchandise add 
Description varchar(255);

alter table merchandise add Price float;



alter table merchandise add Sold boolean;

alter table merchandise add 
SellerShopPayed bool;





INSERT INTO `merchandise` (`MerchandiseID`, `Navn`, `Description`, `Price`, 
`Sold`, `SellerShopPayed`) VALUES
(1, 'LED-TV Full HD', ' Full HD (1920 x 1080p), 
USB, Chromecast port, Smart-tv', 3699.99, false, false),
(2, 'Roof Lamp Milo', 
'Roof lamp with bright pink glass. Height: 24 cm', 529, false, false),
(3, 'Pillow 
Nagano', 'Handcrafted decorative pillow in silk/linen.', 949, false, false),
(4, 
'Cotton Carpet Cochin', 'Soft cotton carpet with fringes on the short sides. 
200x300 cm.', 879, false, false);





create table seller (SellerID int not null, MerchandiseID int not null, foreign 
key(MerchandiseID) references merchandise(MerchandiseID) 
ON DELETE CASCADE, 
primary key(SellerID, MerchandiseID));



alter table seller add FirstName varchar(255);



alter table seller add LastName varchar(255);



alter table seller add Fee float;





INSERT INTO `seller` (`SellerID`, `MerchandiseID`, `FirstName`, `LastName`, `Fee`)
 VALUES
(1, 1, 'Robert', 'Ford', 0.5),
(1, 2, 'Robert', 'Ford', 0.5),
(2, 3, 'Jesse',
 'James', 0.5),
(2, 4, 'Jesse', 'James', 0.5);