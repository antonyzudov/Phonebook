insert into Person (Name, Surname, Patronymic)
output inserted.Id
values (@Name, @Surname, @Patronymic);