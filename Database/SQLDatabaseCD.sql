use master
create database DatabaseCD
go
use DatabaseCD
go

-- ���Ĵ��� --
--�û�myUser--
Create table myUser(
myuID int identity(1,1) primary key,
umail varchar(30) not null unique check(umail like '%@%'),
upswd varchar(12) not null check(Charindex(' ',ltrim(rtrim(upswd)),0) = 0 and Len(upswd)>=8), 
unkname varchar(20) not null, 
uclg varchar(30), 
umj varchar(20), 
uermy varchar(4) check(Len(uermy) = 0 or uermy like '[0-9][0-9][0-9][0-9]'), 
upro varchar(1) check(Len(upro) = 0 or upro in ('1','2','3','4')),
upic image  --3 �������û�ͷ��
)



--��ʦTeacher--
Create table Teacher(
tID int identity(1,1) primary key,
tclg varchar(20) not null check(Len(tclg) != 0),
tmail varchar(30),
toffice varchar(40),
tname varchar(10),
tpic image --3 ��������ʦͷ��
)

--�γ�Course--
Create table Course(
cID int identity(1,1) primary key, 
tID int foreign key  references Teacher(tID) on delete cascade on update cascade,
cname varchar(20), 
cclg varchar(20),
csms varchar(6) check(csms like '[0-9][0-9][0-9][0-9]��' or csms like '[0-9][0-9][0-9][0-9]��'),
ctype char(1) check(ctype in ('1','2','3','4')), 
cppt varchar(12) check(cppt like 'A[0-9][0-9]P[0-9][0-9]H[0-9][0-9]T[0-9][0-9]'), 
coutline image default null, 
cscoring float default null, 
ctcptc float default null, 
chelp float default null, 
chwl char(1) default null,
callScore float default null, --3 ������ƽ������ӡ���
cassnum int default 0  --3 ����������������Ĭ��Ϊ0
)--ͨ��������������õ�5�����������ʡȥ�˴�����������Լ��


--�ղؿγ�myCollection--
--alter���
create table myCollection(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
primary key(myuID,cID)
)

--ȱ������-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------
--������ϢAssessment--
Create table Assessment(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
scoring tinyint check(scoring>=1 and scoring <=5), 
tcptc tinyint check(tcptc>=1 and tcptc <=5), 
help tinyint check(help>=1 and help <=5), 
hwl varchar(10) check(hwl in ('1','2','3','4','5')),
allScore tinyint check(allScore>=1 and allScore <=5) --3 ����������ӡ���
primary key(myuID,cID)
)

--ȱ������
--������ϢReview--
--һ��һ����ֻ������һ�ſγ�һ��
Create table Review(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
rdate date, 
rlike int,
rtext varchar(100)
primary key(myuID,cID,rdate)
)

go
--��������ƣ���������γ̵÷�--
--ÿ�����µ����۲������ݿ⣬���ҿ϶���һ��һ������ģ�
--��ô����Ҫ��������Ӧ�Ŀγ̵ĵ÷֣����Ҹ���Course������Ӧ����Ϣ
--��as�������һ��begin end ����һ������
--3 ������ƽ������ӡ��ֵĸ���,�Լ���������������
create trigger calculating
on Assessment
for Insert
as
begin
	declare @_cID int, @_cscoring float, @_ctcptc float, @_chelp float, @_chwl char(1), @_callScore float

	select @_cID = inserted.cID from inserted

	select @_cscoring = round(Avg(scoring*1.0),1), @_ctcptc = round(Avg(tcptc*1.0),1), @_chelp = round(Avg(help*1.0),1), @_callScore = round(Avg(allScore*1.0),1)
	from Assessment
	where Assessment.cID = @_cID

	select @_chwl = temp.hwl
	from(
		select TOP 1 COUNT(*) as chwl_count, hwl
		from Assessment
		where Assessment.cID = @_cID
		group by Assessment.hwl
		order by COUNT(*) desc) as temp

	update Course
	set Course.cscoring = @_cscoring, Course.ctcptc = @_ctcptc, Course.chelp = @_chelp, Course.chwl = @_chwl, Course.callScore = @_callScore, Course.cassnum += 1
	where Course.cID = @_cID
end


go
--��������������ʾ
create procedure getReview
@_cID int
as
	select rdate,rlike,rtext,unkname,upic,Review.myuID,cID
	from myUser,Review 
	where myUser.myuID=Review.myuID and cID=@_cID
	order by rlike desc

go
--�����������ؼ�gridControl����ʱ��ʾ
CREATE view reviewTest
as
	select rdate,rlike,rtext,unkname,upic,Review.myuID,cID
	from myUser,Review 
	where myUser.myuID=Review.myuID and cID=17

go
--3 ��ͼ�Ĵ���--
--���ڽ�Ͽγ���Ϣ����ʦ��Ϣ�γɿγ���Ŀ
--���ӿγ�cid,��ʦtid,����ռ��cppt
--��ʦ��ҳ����ʦ���ڵ����Կγ�ֱ��ͨ��tid��StaticCourse�����ͼ
--��ת����ϸҳ����Ҫʹ��cid
--------------------------------------------------------------------------------------------
--������ʾ�Ĺ������ȿ��������ͼ
---------------------------------------------------------------------------------------------
create view StaticCourse
as
select cid,cname,cclg, csms, ctype
	=case ctype
	when '1' then  '�������޿�'
	when '2' then  '����ѡ�޿�'
	when '3' then  'רҵ���޿�'
	else 'רҵѡ�޿�' 
	end
	,callScore, cassnum, cscoring, ctcptc, chelp,cppt,
	chwl=case chwl
		when '1' then  '1Сʱ����'
		when '2' then  '1-2Сʱ'
		when '3' then  '2-3Сʱ'
		when '4' then  '3-4Сʱ'
		when '5' then  '4Сʱ����'
		else null end
	,Teacher.tid,tname
from course,teacher
where course.tID=Teacher.tID
go


--���ſγ�
--ѡȡǰ��ʮ�� ���մӸߵ��͵�assessment��������
--����cid ����ת����ϸ�γ�ҳ��
--------------------------------------------------------------------------------------
create view hotCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by cassnum desc

go


--���γ�
--ѡȡǰ��ʮ�� ���մӸߵ��͵�avgscore����
--����cid ����ת����ϸ�γ�ҳ��
--------------------------------------------------------------------------------------
create view redCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by callScore desc
go


--�ڰ�γ�
--ѡȡǰ��ʮ�� ���մӵ͵��ߵ�avgscore����
--����cid ����ת����ϸ�γ�ҳ��
--------------------------------------------------------------------------------------
create view blackCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by callScore asc
go


--���������������--
--myUser--
Insert into myUser
values
('1234567891@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2018','1',null),
('1234567892@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2018','1',null),
('1234567893@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2018','1',null),
('1234567894@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2014','2',null),
('1234567895@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2014','2',null),
('1234567896@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2014','2',null),
('1234567897@qq.com','12345678','����','��������й滮ѧԺ','����ϵ','2012','3',null),
('1234567898@qq.com','12345678','������1','��ľ����ѧԺ','��������ϵ','2018','1',null),
('1234567899@qq.com','12345678','������2','��ľ����ѧԺ','����ϵ','2014','2',null),
('1234567900@qq.com','12345678','������3','���ѧԺ','�������ϵ','2012','3',null),
('1234567910@qq.com','12345678','������4','���ѧԺ','�������ϵ','2012','3',null)
go


--�Ȳ�����ʦ�����ݣ��������Լ����Ӧ���Ȳ��������Ϊ�������ڵı������
--Teacher--
Insert into Teacher
values
('��������й滮ѧԺ','1234567891@tongji.com','A101','����',null),
('��������й滮ѧԺ','1234567892@tongji.com','A102','����',null),
('��������й滮ѧԺ','1234567893@tongji.com','A103','������',null),
('��������й滮ѧԺ','1234567894@tongji.com','A104','����ɽ',null),
('��ľ����ѧԺ','1234567895@tongji.com','E101','��¶ˮ',null),
('�������ѧԺ','1234567896@tongji.com','S103','�ش���',null),
('�������ѧԺ','1234567897@tongji.com','S104','����ʵ',null),
('��������Ϣ����ѧԺ','12345635@tongji.com','���Ź�603','���޼�',null),
('��������Ϣ����ѧԺ','1234562296@tongji.com','���Ź�202','������',null),
('��ľ����ѧԺ','yuankepin@tongji.com','---','Ԭ��Ƽ',null),
('��������й滮ѧԺ','wann@tongji.com','b¥216','������',null)
go
--Course--
Insert into Course
values
(1,'�������','��������й滮ѧԺ','2020��','3','A10P00H40T50',null,null,null,null,null,null,0),
(1,'��������','��������й滮ѧԺ','2020��','3','A10P00H40T50',null,null,null,null,null,null,0),
(1,'����רҵӢ��','��������й滮ѧԺ','2020��','4','A10P00H40T50',null,null,null,null,null,null,0),
(2,'��������','��������й滮ѧԺ','2020��','3','A10P00H40T50',null,null,null,null,null,null,0),
(2,'��ʽ������','��������й滮ѧԺ','2020��','1','A10P00H40T50',null,null,null,null,null,null,0),
(3,'��������','��������й滮ѧԺ','2020��','2','A10P00H40T50',null,null,null,null,null,null,0),
(3,'סլ���','��������й滮ѧԺ','2020��','3','A10P00H40T50',null,null,null,null,null,null,0),
(4,'��������','��������й滮ѧԺ','2020��','3','A10P00H40T50',null,null,null,null,null,null,0),
(5,'���ݿ�ԭ��','��ľ����ѧԺ','2020��','2','A10P00H40T50',null,null,null,null,null,null,0),
(5,'�ṹ��ѧ','��ľ����ѧԺ','2020��','1','A10P00H40T50',null,null,null,null,null,null,0),
(6,'����ϵͳ','�������ѧԺ','2020��','1','A10P00H40T50',null,null,null,null,null,null,0),
(7,'���ݽṹ','�������ѧԺ','2020��','1','A10P00H40T50',null,null,null,null,null,null,0),
(8,'����϶�','��������Ϣ����ѧԺ','2017��','3','A10P00H40T50',null,null,null,null,null,null,0),
(8,'���ֵ��Ӽ���','��������Ϣ����ѧԺ','2018��','3','A10P00H40T50',null,null,null,null,null,null,0),
(9,'ģ����Ӽ���','��������Ϣ����ѧԺ','2019��','3','A10P00H40T50',null,null,null,null,null,null,0),
(9,'Ƕ��ʽϵͳ','��������Ϣ����ѧԺ','2020��','4','A10P00H40T50',null,null,null,null,null,null,0),
(10,'���ݿ⼼��ԭ����Ӧ��','�������ѧԺ','2020��','2','A10P00H40T50',null,null,null,null,null,null,0),
(1,'����滮ԭ��A','��������й滮ѧԺ','2019��','3','A10P00H10T80',null,null,null,null,null,null,0),
(1,'����滮ԭ��B','��������й滮ѧԺ','2020��','3','A10P00H10T80',null,null,null,null,null,null,0),
(1,'����滮ԭ��C','��������й滮ѧԺ','2020��','3','A10P00H10T80',null,null,null,null,null,null,0),
(3,'��������ϸ�滮','��������й滮ѧԺ','2020��','3','A10P00H20T70',null,null,null,null,null,null,0),
(3,'�޽�����ϸ�滮','��������й滮ѧԺ','2020��','3','A10P00H20T70',null,null,null,null,null,null,0),
(3,'��������滮','��������й滮ѧԺ','2019��','3','A10P00H20T70',null,null,null,null,null,null,0),
(4,'����ʷ','��������й滮ѧԺ','2020��','4','A10P00H00T90',null,null,null,null,null,null,0),
(4,'ɫ�ʱ���','��������й滮ѧԺ','2020��','4','A10P00H00T90',null,null,null,null,null,null,0),
(4,'������Ϣϵͳ','��������й滮ѧԺ','2020��','4','A10P00H00T90',null,null,null,null,null,null,0),
(5,'������ѧ','��ľ����ѧԺ','2020��','2','A10P00H00T90',null,null,null,null,null,null,0),
(6,'���������','�������ѧԺ','2020��','2','A10P40H00T60',null,null,null,null,null,null,0),
(7,'���ݽṹ','�������ѧԺ','2019��','1','A10P00H40T50',null,null,null,null,null,null,0),
(7,'���ݽṹ','�������ѧԺ','2019��','1','A10P00H10T80',null,null,null,null,null,null,0),
(11,'��ҵ���','��������й滮ѧԺ','2019��','3','A10P00H10T80',null,null,null,null,null,null,0),--31
(1,'��ҵ���','��������й滮ѧԺ','2020��','3','A10P00H00T90',null,null,null,null,null,null,0),--32
(1,'��ҵ���','��������й滮ѧԺ','2018��','3','A10P00H00T90',null,null,null,null,null,null,0),--33
(1,'��ҵ���','��������й滮ѧԺ','2017��','3','A10P00H00T90',null,null,null,null,null,null,0),--34
(11,'���о���ѧ','��������й滮ѧԺ','2020��','4','A10P00H30T60',null,null,null,null,null,null,0),--35
(11,'���о���ѧ','��������й滮ѧԺ','2019��','4','A10P00H30T60',null,null,null,null,null,null,0),--36
(11,'���̾���ѧ','���������ѧԺ','2020��','4','A10P00H30T60',null,null,null,null,null,null,0),--37
(11,'���򾭼�ѧ','��������й滮ѧԺ','2020��','4','A10P00H30T60',null,null,null,null,null,null,0),--38
(11,'�������ֻ�','��������ѧԺ','2020��','2','A10P00H30T60',null,null,null,null,null,null,0),--39
(11,'����ѧ����','��������й滮ѧԺ','2020��','4','A10P00H30T60',null,null,null,null,null,null,0),--40
(11,'�ݽ���ڲ�','��������й滮ѧԺ','2020��','4','A10P00H70T20',null,null,null,null,null,null,0),--41
(11,'ʫ��','��������й滮ѧԺ','2020��','4','A10P00H70T20',null,null,null,null,null,null,0),--42
(11,'������������','��������й滮ѧԺ','2020��','3','A10P00H70T20',null,null,null,null,null,null,0),--43
(11,'�ռ�䷨����','��������й滮ѧԺ','2020��','4','A10P00H90T00',null,null,null,null,null,null,0),--44
(11,'����ģ����滮','��������й滮ѧԺ','2020��','4','A10P00H70T20',null,null,null,null,null,null,0)--45

go
--myCollection--
Insert into myCollection
values
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,8),
(1,9),
(1,18),
(1,19),
(2,4),
(2,5),
(2,6),
(2,7),
(2,9),
(3,2),
(3,3),
(3,4),
(3,5),
(4,1),
(4,2),
(4,12),
(4,22),
(5,1),
(5,2),
(5,3),
(5,13),
(5,23),
(6,7),
(6,8),
(6,18),
(6,19),
(7,3),
(7,4),
(7,5),
(7,6),
(7,16),
(8,9),
(8,10),
(8,20),
(9,9),
(9,10),
(9,11),
(10,11),
(10,12),
(10,28),
(10,29),
(10,30),
(11,31),
(11,32),
(11,33),
(11,34),
(11,35),
(11,36),
(11,37),
(11,38),
(11,39),
(11,40)


go
--Review--
Insert into Review
values
(1,1,'2020/6/17',1,'��Ȼ���˺ܶ�ʱ�䣬����ѧ���˺ܶණ��'),
(2,1,'2020/6/15',1,'������ѧ'),
(3,1,'2020/6/15',1,'��ʦ��ͼ�ĵĺ���ϸ�������������ģ��'),
(1,2,'2020/6/13',1,'�ǳ�ʵ�õĿγ̣����ᷨ��Ͳ������'),
(3,2,'2020/6/14',0,'Ҫ����Ķ����öడ��̫�Ѽ���'),
(4,2,'2020/6/15',1,'̫���ˣ��ҿ�ǰһ�쿴�����ϣ��ڶ��쿼�Ծ͵�����'),
(5,2,'2020/6/16',1,'������ƿΣ��淶�Ǳ���Ҫ����'),
(1,3,'2020/6/17',0,'̫���ˣ���ʦ�������Ļ����е����'),
(5,3,'2020/6/18',1,'��������ʦ��Ӣ�ĸо�����������'),
(1,4,'2020/6/19',1,'ѧ��֮�����ܶ�������ͼ���Ű���'),
(2,5,'2020/6/20',1,'����ԣ�ϴ����ˮƽ'),
(1,6,'2020/6/21',1,'���ܺ�����˼'),
(6,7,'2020/6/22',1,'��ѧ����һ���µ����ģʽ'),
(6,8,'2020/6/23',0,'���׵���ʦ'),
(9,9,'2020/6/18',1,'�����ʦ�̵�̫���ˣ������ջ�'),
(1,9,'2020/6/19',1,'��רҵѡ�ĿΣ�û�а�ѡ����ʦˮƽ�ߣ�������'),
(2,9,'2020/6/19',1,'ѧ���˺ܶ����õĶ����������������ҳ��'),
(9,10,'2020/6/19',1,'�����۾�ѧ�ģ�̫����'),
(10,11,'2020/6/19',1,'Ӳ�Σ���ѧ���������'),
(5,17,'2020/6/19',1,'����ܺã��´�����'),
(6,17,'2020/6/19',1,'�����λѧ�Ա����������'),
(7,17,'2020/6/19',1,'ͦ�õģ����������е���'),
(10,17,'2020/6/19',1,'¥���������ٵģ���ѡ�����֪����'),
(1,18,'2020/6/20',1,'���ҵĿյ�̫���ˣ�˯�Ĳ����'),
(2,18,'2020/6/20',2,'���ڴ����̫���ˣ�˯�Ĳ����'),
(3,18,'2020/6/20',1,'û��С������ſ�ţ�˯�Ĳ����'),
(4,18,'2020/6/20',0,'¥�϶��ǹ�������ֱ̫���ţ���ʦ��ô���ĵ�Ȼ˯�ĺ����'),
(5,18,'2020/6/20',2,'ΪʲôҪȥ����˯��,Ϊʲô���̿�'),
(5,19,'2020/6/20',1,'ɳ��'),
(5,20,'2020/6/20',1,'ɳ��'),
(5,21,'2020/6/20',1,'ɳ��'),
(5,22,'2020/6/20',1,'ɳ��'),
(5,23,'2020/6/20',1,'ɳ��'),
(5,24,'2020/6/19',1,'ɳ��'),
(6,24,'2020/6/20',10,'�������ǲ���ˮ��'),
(6,25,'2020/6/20',1,'��ѧ��������ѧ'),
(7,25,'2020/6/20',1,'���������ǻ���'),
(8,25,'2020/6/20',1,'��·��������·'),
(1,26,'2020/6/20',1,'��ʦ�������ر�ϸ�ģ��ְ��ִ�����'),
(2,26,'2020/6/20',1,'�����������������װ'),
(3,26,'2020/6/20',1,'�������ø����ֶεõ��Զ��׼��ĵ�����ʲô����'),
(8,27,'2020/6/20',1,'�����ŵ�����'),
(8,28,'2020/6/20',1,'ѡ���ˣ��´λ���'),
(8,29,'2020/6/20',1,'��ʦ����ת���˷����ҵ�������'),
(9,29,'2020/6/20',1,'��ã�����ռ�ȱ�С��'),
(10,29,'2020/6/20',1,'ˮ��')
go


--Assessment--
Insert into Assessment
values
(1,1,4,4,4,'5',4)
Insert into Assessment
values
(2,1,4,4,4,'5',3)
Insert into Assessment
values
(3,1,4,4,4,'5',2)
Insert into Assessment
values
(1,2,4,4,4,'5',5)
Insert into Assessment
values
(3,2,4,5,4,'5',4)
Insert into Assessment
values
(4,2,4,4,4,'5',4)
Insert into Assessment
values
(5,2,4,4,4,'5',4)
Insert into Assessment
values
(1,3,3,3,3,'5',4)
Insert into Assessment
values
(5,3,4,4,4,'5',4)
Insert into Assessment
values
(5,4,4,4,4,'5',3)
Insert into Assessment
values
(1,4,4,4,4,'5',4)
Insert into Assessment
values
(2,5,4,4,4,'5',4)
Insert into Assessment
values
(3,5,4,4,4,'5',1)
Insert into Assessment
values
(4,5,4,4,4,'5',2)
Insert into Assessment
values
(1,6,4,4,4,'5',4)
Insert into Assessment
values
(2,6,5,4,4,'5',5)
Insert into Assessment
values
(3,6,5,4,5,'5',5)
Insert into Assessment
values
(6,7,4,4,4,'5',4)
Insert into Assessment
values
(6,8,4,4,4,'5',4)
Insert into Assessment
values
(9,9,5,5,5,'2',5)
Insert into Assessment
values
(1,9,5,5,5,'3',5)
Insert into Assessment
values
(2,9,5,5,5,'2',5)
Insert into Assessment
values
(3,9,5,5,5,'2',3)
Insert into Assessment
values
(10,9,5,5,5,'2',5)
Insert into Assessment
values
(9,10,4,4,4,'1',4)
Insert into Assessment
values
(10,11,4,4,4,'1',4)
Insert into Assessment
values
(10,12,4,4,4,'4',4)
Insert into Assessment
values
(9,12,5,5,5,'4',5)
Insert into Assessment
values
(8,12,5,5,5,'4',5)
Insert into Assessment
values
(1,17,5,5,5,'4',5)
Insert into Assessment
values
(2,17,5,5,5,'4',5)
Insert into Assessment
values
(3,17,5,5,5,'4',5)
Insert into Assessment
values
(4,17,5,5,5,'4',5)
Insert into Assessment
values
(5,17,5,5,5,'4',5)
Insert into Assessment
values
(6,17,5,5,5,'4',5)
Insert into Assessment
values
(7,17,5,5,5,'4',5)
Insert into Assessment
values
(7,18,3,5,5,'4',5)
Insert into Assessment
values
(6,18,3,5,5,'3',4)
Insert into Assessment
values
(5,18,3,4,5,'3',5)
Insert into Assessment
values
(4,18,1,1,1,'4',1)
Insert into Assessment
values
(3,18,1,1,1,'4',1)
Insert into Assessment
values
(2,18,1,1,1,'4',1)
Insert into Assessment
values
(1,18,1,1,1,'4',2)
Insert into Assessment
values
(2,19,5,4,5,'4',1)
Insert into Assessment
values
(9,19,5,4,5,'4',4)
Insert into Assessment
values
(1,20,5,4,5,'4',4)
Insert into Assessment
values
(2,20,5,4,5,'4',2)
Insert into Assessment
values
(1,21,5,4,3,'4',4)
Insert into Assessment
values
(4,21,4,4,3,'4',2)
Insert into Assessment
values
(1,22,2,4,5,'4',4)
Insert into Assessment
values
(1,23,2,1,1,'4',1)
Insert into Assessment
values
(2,23,2,4,5,'4',2)
Insert into Assessment
values
(3,24,2,4,2,'4',4)
Insert into Assessment
values
(4,25,2,4,5,'4',4)
Insert into Assessment
values
(5,25,2,4,5,'4',3)
Insert into Assessment
values
(6,26,2,4,5,'4',3)
Insert into Assessment
values
(7,26,2,4,5,'4',4)
Insert into Assessment
values
(1,27,5,4,5,'4',5)
Insert into Assessment
values
(1,28,2,4,5,'4',5)
Insert into Assessment
values
(3,28,2,4,5,'4',5)
Insert into Assessment
values
(2,29,2,4,5,'4',4)
Insert into Assessment
values
(3,29,3,5,5,'4',5)
Insert into Assessment
values
(4,29,2,4,5,'4',5)
Insert into Assessment
values
(5,30,5,4,5,'4',4)
Insert into Assessment
values
(6,30,5,4,5,'4',3)
Insert into Assessment
values
(11,31,5,4,5,'4',3)
Insert into Assessment
values
(11,32,5,4,5,'4',2)
Insert into Assessment
values
(11,33,5,4,5,'4',4)
Insert into Assessment
values
(11,34,5,4,5,'4',2)
Insert into Assessment
values
(11,35,5,4,5,'4',3)
Insert into Assessment
values
(11,36,5,4,5,'4',2)
Insert into Assessment
values
(11,37,5,4,5,'4',1)
Insert into Assessment
values
(11,38,5,4,5,'4',1)
Insert into Assessment
values
(11,39,5,4,5,'1',5)
Insert into Assessment
values
(11,40,5,4,5,'1',5)

