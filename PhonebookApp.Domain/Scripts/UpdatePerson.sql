update Person
set Name = @Name,
	Surname = @Surname,
	Patronymic = @Patronymic
where Id = @Id