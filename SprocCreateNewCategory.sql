create procedure CreateNewCategory
(
@categorytype varchar(50),
@categorydescription varchar(50)
)
as

insert into CategoryOfPost(CategoryType, CategoryDescription)
Values (@categorytype, @categorydescription)