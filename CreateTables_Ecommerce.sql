
CREATE TABLE Customer
(	customer_mail			varchar(50) PRIMARY KEY,
	customer_fname			varchar(20) NOT NULL,
	customer_lname			varchar(20) NOT NULL,
	customer_pid			char(9),
	customer_phone			char(10)	NOT NULL,
	customer_city			varchar(20),
	customer_address		varchar(50),
	customer_postal_code	varchar(10)
);

CREATE TABLE Supplier
(	supplier_mail		varchar(50)	PRIMARY KEY,
	supplier_fname		varchar(20) NOT NULL,
	supllier_lname		varchar(20) NOT NULL,
	supplier_pid		char(9),
	supplier_phone		char(10)	NOT NULL,
	supplier_city		varchar(20),
	supplier_address	varchar(50) NOT NULL,
	supplier_company	varchar(30)	NOT NULL,
	supplier_BRC		char(10),
);

CREATE TABLE Administrator
(	admin_mail		varchar(50)	PRIMARY KEY,
	admin_fname		varchar(20) NOT NULL,
	admin_lname		varchar(20) NOT NULL,
	admin_phone		char(10),
	admin_city		varchar(20),
	admin_password	varchar(16) NOT NULL
);

CREATE TABLE Brand
(	brand_name		varchar(20) PRIMARY KEY,
	brand_slogan	varchar(1000),
	brand_country	varchar(20) NOT NULL
)

CREATE TABLE Shipper
(	shipper_pid		char(9) PRIMARY KEY,
	shipper_fname	varchar(20) NOT NULL,
	shipper_lname	varchar(20) NOT NULL,
	shipper_phone	char(10) NOT NULL,
	shipper_address varchar(50),
	shipper_license	char(12) NOT NULL
);

CREATE TABLE Category
(	category_id				int	PRIMARY KEY,
	category_name			varchar(20)	NOT NULL,
	category_picture		varbinary(MAX),
	category_description	varchar(1000),
	category_parentid		int

	CONSTRAINT	fk_category_parentid FOREIGN KEY (category_parentid)
									REFERENCES Category(category_id)
									ON DELETE NO ACTION
);

CREATE TABLE Product
(	product_id			int	PRIMARY KEY,
	product_name		varchar(20)	NOT NULL,
	product_picture		varbinary(MAX),
	product_brand		varchar(20),
	product_categoryid	int,
	product_price		int	NOT NULL,
	product_quantity	int	NOT NULL,
	product_adder		varchar(50)
	
	CONSTRAINT	fk_product_adder FOREIGN KEY(product_adder)
								REFERENCES Administrator(admin_mail)
								ON DELETE SET NULL,
	CONSTRAINT	fk_product_brand FOREIGN KEY(product_brand)
								REFERENCES Brand(brand_name)
								ON DELETE SET NULL,
	CONSTRAINT	fk_product_categoryid FOREIGN KEY(product_categoryid)
								REFERENCES Category(category_id)
								ON DELETE SET NULL
);

CREATE TABLE Orders
(	order_id			int	PRIMARY KEY,
	order_customer_mail	varchar(50) NOT NULL,
	order_date			datetime	NOT NULL,	
	order_status		bit	NOT NULL,
	order_shipvia		varchar(20)

	CONSTRAINT	fk_order_customer_mail FOREIGN KEY(order_customer_mail)
								REFERENCES Customer(customer_mail)
								ON DELETE CASCADE
);

CREATE TABLE OrderDetail
(	detail_order_id		int	NOT NULL,
	detail_number		int NOT NULL,
	detail_product_id	int	NOT NULL,
	detail_quantity		int	NOT NULL,
	detail_unit_price	int	NOT	NULL
	PRIMARY KEY(detail_order_id, detail_number),

	CONSTRAINT fk_detail_order_id	FOREIGN KEY(detail_order_id)
									REFERENCES Orders(order_id)
									ON DELETE CASCADE,
	CONSTRAINT fk_detail_product_id	FOREIGN KEY(detail_product_id)
									REFERENCES Product(product_id)
									ON DELETE NO ACTION
);

CREATE TABLE DiscountCode
(	discount_code_codename		varchar(10) PRIMARY KEY,
	discount_code_ispercent		bit	NOT NULL,
	discount_code_amount		decimal(10, 2)	NOT NULL,
	discount_code_max_amount	money	NOT NULL,
	discount_code_expdate		datetime	NOT NULL
);

CREATE TABLE DiscountCity
(	discount_city_name		varchar(20) NOT NULL,
	discount_city_codename	varchar(10) NOT NULL
	PRIMARY KEY(discount_city_name, discount_city_codename),

	CONSTRAINT fk_discount_city_codename FOREIGN KEY (discount_city_codename)
										REFERENCES DiscountCode(discount_code_codename)
										ON DELETE CASCADE
);

CREATE TABLE CreditCard
(	credit_card_customer_mail	varchar(50)	NOT NULL,
	credit_card_id				char(16)	PRIMARY KEY,
	credit_card_bank			varchar(20) NOT NULL,
	credit_card_expdate			date	NOT NULL
	
	CONSTRAINT fk_credit_card_customer_mail FOREIGN KEY(credit_card_customer_mail)
										REFERENCES Customer(customer_mail)
										ON DELETE CASCADE
);

CREATE TABLE EWallet
(	ewallet_customer_mail		varchar(50)	NOT NULL,
	ewallet_name				varchar(10)	NOT NULL,
	ewallet_linked_phone		char(10)	NOT NULL
	PRIMARY KEY(ewallet_customer_mail, ewallet_name)
	
	CONSTRAINT fk_ewallet_customer_mail FOREIGN KEY(ewallet_customer_mail)
										REFERENCES Customer(customer_mail)
										ON DELETE CASCADE
);

CREATE TABLE Review
(	review_no				int	PRIMARY KEY,
	review_rating			int	NOT NULL,
	review_comment			varchar(1000),
	review_picture			varbinary(MAX),
	review_customer_mail	varchar(50)	NOT NULL,
	review_product_id		int	NOT NULL

	CONSTRAINT fk_review_customer_mail FOREIGN KEY(review_customer_mail)
										REFERENCES Customer(customer_mail)
										ON DELETE NO ACTION,

	CONSTRAINT fk_review_product_id FOREIGN KEY(review_product_id)
										REFERENCES Product(product_id)
										ON DELETE NO ACTION
);

CREATE TABLE Bill
(	bill_id						int	PRIMARY KEY,
	bill_customer_mail			varchar(50)	NOT NULL,
	bill_order_id				int	NOT NULL,
	bill_address				varchar(50)	NOT NULL,
	bill_date					datetime	NOT NULL,
	bill_payment_method			varchar(10)	NOT NULL,
	bill_credit_card_id			char(16),
	bill_ewallet_name			varchar(10)

	CONSTRAINT fk_bill_customer_mail FOREIGN KEY(bill_customer_mail)
										REFERENCES Customer(customer_mail)
										ON DELETE CASCADE,

	CONSTRAINT fk_bill_order_id FOREIGN KEY(bill_order_id)
										REFERENCES Orders(order_id)
										ON DELETE NO ACTION,

	CONSTRAINT fk_bill_credit_card_id FOREIGN KEY(bill_credit_card_id)
										REFERENCES CreditCard(credit_card_id)
										ON DELETE NO ACTION,

	CONSTRAINT fk_bill_ewallet_linked_phone FOREIGN KEY(bill_customer_mail, bill_ewallet_name)
										REFERENCES EWallet(ewallet_customer_mail, ewallet_name)
										ON DELETE NO ACTION
);

CREATE TABLE Supply
(	supply_product_id		int,
	supply_supplier_mail	varchar(50)
	PRIMARY KEY(supply_product_id, supply_supplier_mail)

	CONSTRAINT fk_supply_product_id FOREIGN KEY(supply_product_id)	
									REFERENCES Product(product_id)
									ON DELETE CASCADE,
	
	CONSTRAINT fk_supply_supplier_mail FOREIGN KEY(supply_supplier_mail)	
									REFERENCES Supplier(supplier_mail)
									ON DELETE CASCADE
);

CREATE TABLE Ship
(	ship_order_id		int,
	ship_shipper_pid	char(9),
	ship_date			datetime
	PRIMARY KEY(ship_order_id, ship_shipper_pid)

	CONSTRAINT fk_ship_order_id FOREIGN KEY(ship_order_id)	
									REFERENCES Orders(order_id)
									ON DELETE NO ACTION,
	
	CONSTRAINT fk_ship_shipper_pid FOREIGN KEY(ship_shipper_pid)	
									REFERENCES Shipper(shipper_pid)
									ON DELETE CASCADE
);

CREATE TABLE Discount
(	discount_customer_mail	varchar(50),
	discount_order_id		int UNIQUE,
	discount_discount_codename	varchar(10)
	PRIMARY KEY(discount_customer_mail, discount_discount_codename),

	CONSTRAINT fk_discount_customer_mail	FOREIGN KEY(discount_customer_mail)
									REFERENCES Customer(customer_mail)
									ON DELETE NO ACTION,

	CONSTRAINT fk_discount_order_id	FOREIGN KEY(discount_order_id)
									REFERENCES Orders(order_id)
									ON DELETE NO ACTION,
	
	CONSTRAINT fk_discount_discount_codename FOREIGN KEY(discount_discount_codename)	
										REFERENCES DiscountCode(discount_code_codename)
										ON DELETE CASCADE
);

CREATE INDEX index_customer ON Customer (customer_mail)
CREATE INDEX index_supplier ON Supplier(supplier_mail)
CREATE INDEX index_administrator ON Administrator(admin_mail)
CREATE INDEX index_brand ON Brand(brand_name)
CREATE INDEX index_shipper ON Shipper(shipper_pid)
CREATE INDEX index_category ON Category(category_id)
CREATE INDEX index_product ON Product(product_id)
CREATE INDEX index_order ON Orders(order_id)
CREATE INDEX index_order_detail ON OrderDetail(detail_order_id)
CREATE INDEX index_discount_code ON DiscountCode(discount_code_codename)
CREATE INDEX index_discount_city ON DiscountCity(discount_city_name)
CREATE INDEX index_credit_card ON CreditCard(credit_card_id)
CREATE INDEX index_ewallet ON EWallet(ewallet_name)
CREATE INDEX index_review ON Review(review_no)
CREATE INDEX index_bill ON Bill(bill_id)
CREATE INDEX index_supply ON Supply(supply_product_id)
CREATE INDEX index_ship ON Ship(ship_order_id)
CREATE INDEX index_discount ON Discount(discount_order_id)
		