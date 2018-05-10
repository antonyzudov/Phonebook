select 
	p.Id,
	p.Name,
	p.Surname,
	p.Patronymic
from Person p
where p.Id = @Id