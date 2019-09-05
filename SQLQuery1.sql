select * from games

insert into games 
select Name,Year,Producer_Id from games

select count(*) from games