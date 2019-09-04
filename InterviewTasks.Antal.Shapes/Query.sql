create table Interview.Article (id int identity(1,1) primary key, topic nvarchar(max) not null);
create table Interview.Tag (id int identity(1,1) primary key, tag nvarchar(max) not null);
create table Interview.ArticleTag(id int identity(1,1) primary key, articleid int not null, tagid int not null,
	constraint fk_articletag_article foreign key (articleid) references Interview.Article (id),
	constraint fk_articletag_tag foreign key (tagid) references Interview.Tag (id));

insert into Interview.Article (topic) values ('topic 1'), ('topic 2'), ('topic 3'), ('topic 4'), ('topic 5'), ('topic 6'), ('topic 7');
insert into Interview.Tag (tag) values ('tag 1'), ('tag 2'), ('tag 3'), ('tag 4');
insert into Interview.ArticleTag (articleid, tagid) values (1, 1), (1, 2), (2, 2), (2, 3), (2, 4), (3, 1), (3, 2), (3, 3);

select Ar.topic, Tg.tag
from Interview.Article as Ar
left join Interview.ArticleTag as ArTg
on Ar.id = ArTg.articleid
left join Interview.Tag as Tg
on ArTg.tagid = Tg.id;