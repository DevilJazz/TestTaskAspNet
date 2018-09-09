Select Count(OrderID) from Orders where "FromPeriod" <= CreationDate and CreationDate < "AfterPeriod" group by Manager 
