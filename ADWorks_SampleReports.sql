--=================================================
-- Dashboard Related Reports
--=================================================
--Total Sales for the year 2014
select ROUND(SUM(TotalDue),2) from Sales.SalesOrderHeader 
where YEAR(OrderDate)=2014

--Total Customers
select count(*) from Sales.Customer

--Customer Count Line chart Dataset
select YEAR(ModifiedDate) ,COUNT(CustomerID) from Sales.Customer
group by YEAR(ModifiedDate)


--Yearly Territory Sales Report for 2014
select t.Name as 'name',round(SUM(s.TotalDue),2) as 'value'
from Sales.SalesOrderHeader s
join Sales.SalesTerritory t
on t.TerritoryID = s.TerritoryID
where year(s.OrderDate)=2014
group by t.Name
order by t.Name asc


--Product Sales Report by year
select c.Name  as 'name',
	   convert(decimal(38,2),sum(s.LineTotal)) as 'value'
from Sales.SalesOrderDetail s
join Production.Product p 
on p.ProductID = s.ProductID
join Production.ProductCategory c
on p.ProductSubcategoryID =c.ProductCategoryID
join Sales.SalesOrderHeader h
on h.SalesOrderID = s.SalesOrderID
where year(h.OrderDate)=2012
group by  c.Name  
order by c.Name asc

--Pending Shipment for Calander
select top(1) concat('#',SalesOrderID,space(2),'Order Date:',format(OrderDate,'yyyy-MM-dd'),
	   space(2),'Ship Date:',format(ShipDate,'yyyy-MM-dd')) as 'title',
	   format(ShipDate,'yyyy-MM-dd') as 'date'
from Sales.SalesOrderHeader
where year(ShipDate)=2014



--=================================================
-- Production Related Reports
--=================================================

--Assembly Line JSON Result based on location ID
select wr.WorkOrderID ,
	   p.Name as 'ProductName',
	   wo.OrderQty,
	   'CurrentStage'= case(wr.OperationSequence)
	   when 1 then 'Forming'
	   when 2 then 'Welding'
	   when 3 then 'Debur and Polish'
	   when 4 then 'Paint'
	   when 5 then 'Specialized Paint'
	   when 6 then 'Subassembly'
	   when 7 then 'Final Assembly'
	   end,
	  'AssemblyArea'= case(wr.LocationID)
	   when 10 then 'Frame Forming'
	   when 20 then 'Frame Welding'
	   when 30 then 'Debur and Polish'
	   when 40 then 'Paint Zone'
	   when 45 then 'Specialized Paint'
	   when 50 then 'Subassembly'
	   when 60 then 'Final Assembly'
	   end,
	   wr.ActualResourceHrs,
	   wr.PlannedCost,
	   wr.ActualCost,
	  format(wr.ActualStartDate,'yyyy-MM-dd') as 'StartDate',
	  format(wr.ActualEndDate,'yyyy-MM-dd') as 'EndDate'
from Production.WorkOrderRouting wr
join Production.Product p 
on p.ProductID = wr.ProductID
join Production.WorkOrder wo 
on wr.WorkOrderID = wo.WorkOrderID
where LocationID=10


--Total Work Order Received / Completed / Delayed / Scraped
select COUNT(*) from Production.WorkOrder

--Completed
select COUNT(*) from Production.WorkOrder
where EndDate < = DueDate

--Delayed
select COUNT(*) from Production.WorkOrder
where EndDate > DueDate

--Scraped
select COUNT(*) from Production.WorkOrder
where ScrapReasonID is not null


--Work Order Received but Job Not Yet Started JSON Result
select wo.WorkOrderID,
	   wo.ProductID,
	   wo.OrderQty,
	   wo.StockedQty,
	   wo.StartDate,
	   wo.EndDate,
	   wo.DueDate
from Production.WorkOrder wo
where WorkOrderID not in (select WorkOrderID from Production.WorkOrderRouting)


--Work Order Completed JSON Result
select wo.WorkOrderID,
	   wo.ProductID,
	   wo.OrderQty,
	   wo.StockedQty,
	   wo.StartDate,
	   wo.EndDate,
	   wo.DueDate
from Production.WorkOrder wo
where wo.EndDate < = wo.DueDate
and wo.ScrapReasonID is null


--Work Order Delayed JSON Result
select wo.WorkOrderID,
	   wo.ProductID,
	   wo.OrderQty,
	   wo.StockedQty,
	   wo.StartDate,
	   wo.EndDate,
	   wo.DueDate
from Production.WorkOrder wo
where wo.EndDate > wo.DueDate
and wo.ScrapReasonID is null


--Scraped Worked Order JSON result 
select wo.WorkOrderID,
	   wo.ProductID,
	   wo.OrderQty,
	   wo.StockedQty,
	   wo.ScrappedQty,
	   r.Name
from Production.WorkOrder wo 
join Production.ScrapReason r
on wo.ScrapReasonID = r.ScrapReasonID
where wo.ScrapReasonID is not null


--Stock & Inventory  in-stock / out of stock / running low
with cte as (
	select p.ProductID , SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
	from Production.Product p
	join  Production.ProductInventory i
	on p.ProductID = i.ProductID
	group by p.ProductID  , p.SafetyStockLevel
)
select count(*) from cte
where CurrentStock > SafetyStockLevel 

--running low
with cte as (
	select p.ProductID , SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
	from Production.Product p
	join  Production.ProductInventory i
	on p.ProductID = i.ProductID
	group by p.ProductID  , p.SafetyStockLevel
)
select count(*) from cte
where CurrentStock < SafetyStockLevel and CurrentStock !=0

--out of stock
with cte as (
	select p.ProductID , SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
	from Production.Product p
	join  Production.ProductInventory i
	on p.ProductID = i.ProductID
	group by p.ProductID  , p.SafetyStockLevel
)
select count(*) from cte
where CurrentStock = 0


--Inventory JSON result
with cte as (
	select p.ProductID ,p.Name, SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
	from Production.Product p
	join  Production.ProductInventory i
	on p.ProductID = i.ProductID
	group by p.ProductID  , p.SafetyStockLevel , p.Name
)
select * from cte order by CurrentStock asc


--=================================================
-- Sales Related Reports
--=================================================

-- All Products View
select  ProductID,
		Name,
		Category,
		SubCategory,
		Model,
		ProductNumber,
		Color,
		ListPrice,
		Style,
		ProductLine,
		Class,
		Weight,
		WeightUnitMeasureCode,
		Size,
		SizeUnitMeasureCode,
		Description
from Sales.VW_Products


-- Product Photo 
select  ThumbNailPhoto,
		ThumbnailPhotoFileName,
		LargePhoto,
		LargePhotoFileName
from Sales.VW_Products
where ProductID = 680

-- Product Ratings 
select pr.ProductID,
	   pr.Rating,
	   pr.Comments
from Production.ProductReview pr 
join Production.Product p
on pr.ProductID = p.ProductID
where pr.ProductID=709

--Store Details City and Lat Long
select * from Purchasing.vVendorWithAddresses

-- Sales Order Header 
select * from [Sales].[VW_SalesOrderHeader]

alter view [Sales].[VW_SalesOrderHeader]
as
select distinct oh.SalesOrderID,
	   format(oh.OrderDate,'yyyy-MM-dd') as 'OrderDate',
	   'Status'=case(oh.Status)
		when 1 then 'In process'
		when 2 then 'Approved'
		when 3 then 'Backordered'
		when 4 then 'Rejected'
		when 5 then 'Shipped'
		when 6 then 'Cancelled'
	   end,
	   oh.AccountNumber,
	   oh.CustomerID,
	   format(oh.ShipDate,'yyyy-MM-dd') as 'ShipDate',
	   sm.Name as 'ShippedBy',
	   od.CarrierTrackingNumber as 'TrackingNumber',
	   oh.SubTotal as 'SubTotal',
	   oh.Freight as 'DeliveryChg',
	   oh.TaxAmt,
	   oh.TotalDue
from Sales.SalesOrderHeader oh
join Sales.SalesOrderDetail od
on oh.SalesOrderID = od.SalesOrderID
join Purchasing.ShipMethod sm
on sm.ShipMethodID = oh.ShipMethodID

-- sales order detailer 
select od.SalesOrderID,
	   od.SalesOrderDetailID,
	   od.ProductID,
	   p.Name,
	   od.UnitPrice,
	   od.OrderQty,
	   od.LineTotal
from Sales.SalesOrderDetail od
join Production.Product p 
on od.ProductID = p.ProductID
where od.SalesOrderID = 43659


--Quaterly Territory Sales Report 
select year(s.OrderDate) as 'year', 
	   datepart(QQ,s.OrderDate) as 'Q',
	   t.Name,
	   sum(s.TotalDue) 'Sales'
from Sales.SalesOrderHeader s
join Sales.SalesTerritory t
on t.TerritoryID = s.TerritoryID
group by year(s.OrderDate),datepart(QQ,s.OrderDate) ,t.TerritoryID, t.Name
order by year(s.OrderDate) desc, datepart(QQ,s.OrderDate) asc 


--Quaterly Product Sales Report
select year(h.OrderDate) as 'Year',
	   datepart(QQ,h.OrderDate) as 'Quater',
	   c.Name,
	   sum(s.LineTotal) as 'Sales'
from Sales.SalesOrderDetail s
join Production.Product p 
on p.ProductID = s.ProductID
join Production.ProductCategory c
on p.ProductSubcategoryID =c.ProductCategoryID
join Sales.SalesOrderHeader h
on h.SalesOrderID = s.SalesOrderID
where year(h.OrderDate)=2013
group by year(h.OrderDate) , datepart(QQ,h.OrderDate) ,c.ProductCategoryID, c.Name  
order by year(h.OrderDate) desc ,datepart(QQ,h.OrderDate) asc, c.Name asc



--=================================================
-- Purchase Related Reports
--=================================================

-- Products running low or out of stock
with cte as (
	select p.ProductID ,p.Name,  SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
	from Production.Product p
	join  Production.ProductInventory i
	on p.ProductID = i.ProductID
	group by p.ProductID  ,p.Name, p.SafetyStockLevel)
select * from cte
where CurrentStock <= SafetyStockLevel
order by CurrentStock asc

select * from Purchasing.ProductVendor where ProductID = 853
select * from Purchasing.Vendor where BusinessEntityID = 1594

select * from Purchasing.vVendorWithContacts where BusinessEntityID = 1594

select * from Purchasing.vVendorWithAddresses where BusinessEntityID = 1594

-- vendor details 
select va.BusinessEntityID,
	   va.Name as 'VendorName',
	   va.AddressLine1,
	   va.AddressLine2, 
	   va.City,
	   va.StateProvinceName,
	   va.CountryRegionName,
	   va.PostalCode,
	   vc.ContactType,
	   vc.FirstName,
	   vc.MiddleName,
	   vc.LastName,
	   vc.PhoneNumber,
	   vc.EmailAddress 
from Purchasing.vVendorWithAddresses va
join Purchasing.vVendorWithContacts vc
on va.BusinessEntityID = vc.BusinessEntityID

-- shipping types and rate chart
select * from Purchasing.ShipMethod


--purchase order header
select poh.PurchaseOrderID,
	   format(poh.OrderDate,'yyyy-MM-dd') as 'OrderDate',
	   poh.RevisionNumber,
	   'Status'=case(poh.Status)
				when '1' then 'Pending'
				when '2' then 'Approved'
				when '3' then 'Rejected'
				when '4' then 'Complete '
				end,
				p.FirstName+space(2)+p.LastName 'PlacedBy',
				poh.VendorID,
				sm.Name as 'ShippedThrough',
				poh.SubTotal,
				poh.Freight,
				poh.TaxAmt,
				poh.TotalDue
from Purchasing.PurchaseOrderHeader poh
join Purchasing.ShipMethod sm
on poh.ShipMethodID = sm.ShipMethodID
join HumanResources.Employee e
on poh.EmployeeID = e.BusinessEntityID
join Person.Person p 
on e.BusinessEntityID = p.BusinessEntityID

-- Purchase Order Detailer
select po.*, p.Name from Purchasing.PurchaseOrderDetail  po
join Production.Product p 
on po.ProductID = p.ProductID
--=================================================
-- HR Related Reports
--=================================================

-- all emp details view 

select * from HumanResources.VW_Employee
       --e.BusinessEntityID ,
	   --e.JobTitle as 'Designation',
	   --d.Name as 'Department',
	   --d.GroupName as 'Group',
	   --'Grade'='A',
	   --e.HireDate as 'DOJ',
	   --s.Name as 'CurrentShift',
	   --e.SickLeaveHours,
	   --e.VacationHours,
	   --p.FirstName,
	   --p.MiddleName,
	   --p.LastName,
	   --e.Gender,
	   --e.MaritalStatus,
	   --e.BirthDate as 'DOB',
	   --em.EmailAddress,
	   --pp.PhoneNumber,
	   --a.AddressLine1,
	   --cr.Name as 'Country',
	   --sp.Name as 'State',
	   --a.City,
	   --a.PostalCode 


WITH XMLNAMESPACES ('http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/Resume' AS ns)
SELECT [Resume].query('(//ns:Name.Last)').value('.[1]', 'nvarchar(100)')
FROM   HumanResources.JobCandidate;

select FORMAT(BirthDate,'dd-MMM-yyyy') from HumanResources.Employee

