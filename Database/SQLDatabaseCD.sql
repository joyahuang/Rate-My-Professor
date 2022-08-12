use master
create database DatabaseCD
go
use DatabaseCD
go

-- 表格的创建 --
--用户myUser--
Create table myUser(
myuID int identity(1,1) primary key,
umail varchar(30) not null unique check(umail like '%@%'),
upswd varchar(12) not null check(Charindex(' ',ltrim(rtrim(upswd)),0) = 0 and Len(upswd)>=8), 
unkname varchar(20) not null, 
uclg varchar(30), 
umj varchar(20), 
uermy varchar(4) check(Len(uermy) = 0 or uermy like '[0-9][0-9][0-9][0-9]'), 
upro varchar(1) check(Len(upro) = 0 or upro in ('1','2','3','4')),
upic image  --3 增加了用户头像
)



--教师Teacher--
Create table Teacher(
tID int identity(1,1) primary key,
tclg varchar(20) not null check(Len(tclg) != 0),
tmail varchar(30),
toffice varchar(40),
tname varchar(10),
tpic image --3 增加了老师头像
)

--课程Course--
Create table Course(
cID int identity(1,1) primary key, 
tID int foreign key  references Teacher(tID) on delete cascade on update cascade,
cname varchar(20), 
cclg varchar(20),
csms varchar(6) check(csms like '[0-9][0-9][0-9][0-9]春' or csms like '[0-9][0-9][0-9][0-9]秋'),
ctype char(1) check(ctype in ('1','2','3','4')), 
cppt varchar(12) check(cppt like 'A[0-9][0-9]P[0-9][0-9]H[0-9][0-9]T[0-9][0-9]'), 
coutline image default null, 
cscoring float default null, 
ctcptc float default null, 
chelp float default null, 
chwl char(1) default null,
callScore float default null, --3 增加了平均整体印象分
cassnum int default 0  --3 增加了评价人数，默认为0
)--通过触发器来计算得到5个评分项，于是省去此处的域完整性约束


--收藏课程myCollection--
--alter语句
create table myCollection(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
primary key(myuID,cID)
)

--缺少主键-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------
--评价信息Assessment--
Create table Assessment(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
scoring tinyint check(scoring>=1 and scoring <=5), 
tcptc tinyint check(tcptc>=1 and tcptc <=5), 
help tinyint check(help>=1 and help <=5), 
hwl varchar(10) check(hwl in ('1','2','3','4','5')),
allScore tinyint check(allScore>=1 and allScore <=5) --3 增加了整体印象分
primary key(myuID,cID)
)

--缺少主键
--评论信息Review--
--一天一个人只能评价一门课程一次
Create table Review(
myuID int foreign key references myUser(myuID) on delete cascade on update cascade,
cID int foreign key references Course(cID) on delete cascade on update cascade,
rdate date, 
rlike int,
rtext varchar(100)
primary key(myuID,cID,rdate)
)

go
--触发器设计，用来计算课程得分--
--每当有新的评价插入数据库，并且肯定是一条一条插入的，
--那么就需要计算所对应的课程的得分，并且更新Course表格里对应的信息
--在as后面加了一个begin end 或许不一定有用
--3 增加了平均整体印象分的更新,以及评价人数的增加
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
--用于评论区的显示
create procedure getReview
@_cID int
as
	select rdate,rlike,rtext,unkname,upic,Review.myuID,cID
	from myUser,Review 
	where myUser.myuID=Review.myuID and cID=@_cID
	order by rlike desc

go
--用于评论区控件gridControl的临时显示
CREATE view reviewTest
as
	select rdate,rlike,rtext,unkname,upic,Review.myuID,cID
	from myUser,Review 
	where myUser.myuID=Review.myuID and cID=17

go
--3 视图的创建--
--用于结合课程信息和老师信息形成课程条目
--增加课程cid,老师tid,分数占比cppt
--老师主页下老师教授的所以课程直接通过tid查StaticCourse这个视图
--跳转到详细页面需要使用cid
--------------------------------------------------------------------------------------------
--搜索显示的功能优先考虑这个视图
---------------------------------------------------------------------------------------------
create view StaticCourse
as
select cid,cname,cclg, csms, ctype
	=case ctype
	when '1' then  '公共必修课'
	when '2' then  '公共选修课'
	when '3' then  '专业必修课'
	else '专业选修课' 
	end
	,callScore, cassnum, cscoring, ctcptc, chelp,cppt,
	chwl=case chwl
		when '1' then  '1小时以下'
		when '2' then  '1-2小时'
		when '3' then  '2-3小时'
		when '4' then  '3-4小时'
		when '5' then  '4小时以上'
		else null end
	,Teacher.tid,tname
from course,teacher
where course.tID=Teacher.tID
go


--热门课程
--选取前二十个 按照从高到低的assessment数量排序
--增加cid 可以转到详细课程页面
--------------------------------------------------------------------------------------
create view hotCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by cassnum desc

go


--红榜课程
--选取前二十个 按照从高到低的avgscore排序
--增加cid 可以转到详细课程页面
--------------------------------------------------------------------------------------
create view redCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by callScore desc
go


--黑榜课程
--选取前二十个 按照从低到高的avgscore排序
--增加cid 可以转到详细课程页面
--------------------------------------------------------------------------------------
create view blackCourse
as
select top 20
 cid,cname,cclg, csms, ctype, callScore, cassnum, cscoring, ctcptc, chelp, chwl, tname
from StaticCourse
where callScore is not null
order by callScore asc
go


--导入测试用例数据--
--myUser--
Insert into myUser
values
('1234567891@qq.com','12345678','张三','建筑与城市规划学院','建筑系','2018','1',null),
('1234567892@qq.com','12345678','张四','建筑与城市规划学院','建筑系','2018','1',null),
('1234567893@qq.com','12345678','张五','建筑与城市规划学院','建筑系','2018','1',null),
('1234567894@qq.com','12345678','李三','建筑与城市规划学院','建筑系','2014','2',null),
('1234567895@qq.com','12345678','李四','建筑与城市规划学院','建筑系','2014','2',null),
('1234567896@qq.com','12345678','李五','建筑与城市规划学院','建筑系','2014','2',null),
('1234567897@qq.com','12345678','王三','建筑与城市规划学院','建筑系','2012','3',null),
('1234567898@qq.com','12345678','神秘人1','土木工程学院','建筑工程系','2018','1',null),
('1234567899@qq.com','12345678','神秘人2','土木工程学院','桥梁系','2014','2',null),
('1234567900@qq.com','12345678','神秘人3','软件学院','软件工程系','2012','3',null),
('1234567910@qq.com','12345678','神秘人4','软件学院','软件工程系','2012','3',null)
go


--先插入老师的数据，按照外键约束，应该先插入外键作为主键所在的表的数据
--Teacher--
Insert into Teacher
values
('建筑与城市规划学院','1234567891@tongji.com','A101','王华',null),
('建筑与城市规划学院','1234567892@tongji.com','A102','张玲',null),
('建筑与城市规划学院','1234567893@tongji.com','A103','李梦翔',null),
('建筑与城市规划学院','1234567894@tongji.com','A104','彰显山',null),
('土木工程学院','1234567895@tongji.com','E101','洪露水',null),
('软件工程学院','1234567896@tongji.com','S103','秦春华',null),
('软件工程学院','1234567897@tongji.com','S104','刘秋实',null),
('电子与信息工程学院','12345635@tongji.com','智信馆603','赵无极',null),
('电子与信息工程学院','1234562296@tongji.com','智信馆202','张三丰',null),
('土木工程学院','yuankepin@tongji.com','---','袁科萍',null),
('建筑与城市规划学院','wann@tongji.com','b楼216','万能人',null)
go
--Course--
Insert into Course
values
(1,'城市设计','建筑与城市规划学院','2020春','3','A10P00H40T50',null,null,null,null,null,null,0),
(1,'建筑法规','建筑与城市规划学院','2020春','3','A10P00H40T50',null,null,null,null,null,null,0),
(1,'建筑专业英语','建筑与城市规划学院','2020春','4','A10P00H40T50',null,null,null,null,null,null,0),
(2,'建筑构造','建筑与城市规划学院','2020春','3','A10P00H40T50',null,null,null,null,null,null,0),
(2,'形式与政策','建筑与城市规划学院','2020春','1','A10P00H40T50',null,null,null,null,null,null,0),
(3,'雕塑艺术','建筑与城市规划学院','2020春','2','A10P00H40T50',null,null,null,null,null,null,0),
(3,'住宅设计','建筑与城市规划学院','2020春','3','A10P00H40T50',null,null,null,null,null,null,0),
(4,'艺术造型','建筑与城市规划学院','2020春','3','A10P00H40T50',null,null,null,null,null,null,0),
(5,'数据库原理','土木工程学院','2020春','2','A10P00H40T50',null,null,null,null,null,null,0),
(5,'结构力学','土木工程学院','2020春','1','A10P00H40T50',null,null,null,null,null,null,0),
(6,'操作系统','软件工程学院','2020春','1','A10P00H40T50',null,null,null,null,null,null,0),
(7,'数据结构','软件工程学院','2020春','1','A10P00H40T50',null,null,null,null,null,null,0),
(8,'电机拖动','电子与信息工程学院','2017春','3','A10P00H40T50',null,null,null,null,null,null,0),
(8,'数字电子技术','电子与信息工程学院','2018春','3','A10P00H40T50',null,null,null,null,null,null,0),
(9,'模拟电子技术','电子与信息工程学院','2019春','3','A10P00H40T50',null,null,null,null,null,null,0),
(9,'嵌入式系统','电子与信息工程学院','2020秋','4','A10P00H40T50',null,null,null,null,null,null,0),
(10,'数据库技术原理与应用','软件工程学院','2020秋','2','A10P00H40T50',null,null,null,null,null,null,0),
(1,'城乡规划原理A','建筑与城市规划学院','2019春','3','A10P00H10T80',null,null,null,null,null,null,0),
(1,'城乡规划原理B','建筑与城市规划学院','2020春','3','A10P00H10T80',null,null,null,null,null,null,0),
(1,'城乡规划原理C','建筑与城市规划学院','2020秋','3','A10P00H10T80',null,null,null,null,null,null,0),
(3,'控制性详细规划','建筑与城市规划学院','2020秋','3','A10P00H20T70',null,null,null,null,null,null,0),
(3,'修建性详细规划','建筑与城市规划学院','2020秋','3','A10P00H20T70',null,null,null,null,null,null,0),
(3,'城市总体规划','建筑与城市规划学院','2019春','3','A10P00H20T70',null,null,null,null,null,null,0),
(4,'艺术史','建筑与城市规划学院','2020秋','4','A10P00H00T90',null,null,null,null,null,null,0),
(4,'色彩表现','建筑与城市规划学院','2020秋','4','A10P00H00T90',null,null,null,null,null,null,0),
(4,'地理信息系统','建筑与城市规划学院','2020秋','4','A10P00H00T90',null,null,null,null,null,null,0),
(5,'弹性力学','土木工程学院','2020秋','2','A10P00H00T90',null,null,null,null,null,null,0),
(6,'计算机网络','软件工程学院','2020秋','2','A10P40H00T60',null,null,null,null,null,null,0),
(7,'数据结构','软件工程学院','2019秋','1','A10P00H40T50',null,null,null,null,null,null,0),
(7,'数据结构','软件工程学院','2019春','1','A10P00H10T80',null,null,null,null,null,null,0),
(11,'毕业设计','建筑与城市规划学院','2019春','3','A10P00H10T80',null,null,null,null,null,null,0),--31
(1,'毕业设计','建筑与城市规划学院','2020春','3','A10P00H00T90',null,null,null,null,null,null,0),--32
(1,'毕业设计','建筑与城市规划学院','2018春','3','A10P00H00T90',null,null,null,null,null,null,0),--33
(1,'毕业设计','建筑与城市规划学院','2017春','3','A10P00H00T90',null,null,null,null,null,null,0),--34
(11,'城市经济学','建筑与城市规划学院','2020春','4','A10P00H30T60',null,null,null,null,null,null,0),--35
(11,'城市经济学','建筑与城市规划学院','2019春','4','A10P00H30T60',null,null,null,null,null,null,0),--36
(11,'工程经济学','经济与管理学院','2020春','4','A10P00H30T60',null,null,null,null,null,null,0),--37
(11,'区域经济学','建筑与城市规划学院','2020秋','4','A10P00H30T60',null,null,null,null,null,null,0),--38
(11,'星期音乐会','新闻联播学院','2020春','2','A10P00H30T60',null,null,null,null,null,null,0),--39
(11,'建筑学导论','建筑与城市规划学院','2020春','4','A10P00H30T60',null,null,null,null,null,null,0),--40
(11,'演讲与口才','建筑与城市规划学院','2020春','4','A10P00H70T20',null,null,null,null,null,null,0),--41
(11,'诗经','建筑与城市规划学院','2020春','4','A10P00H70T20',null,null,null,null,null,null,0),--42
(11,'计算机辅助设计','建筑与城市规划学院','2020春','3','A10P00H70T20',null,null,null,null,null,null,0),--43
(11,'空间句法概论','建筑与城市规划学院','2020春','4','A10P00H90T00',null,null,null,null,null,null,0),--44
(11,'城市模拟与规划','建筑与城市规划学院','2020春','4','A10P00H70T20',null,null,null,null,null,null,0)--45

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
(1,1,'2020/6/17',1,'虽然花了很多时间，但是学到了很多东西'),
(2,1,'2020/6/15',1,'过于玄学'),
(3,1,'2020/6/15',1,'老师改图改的很仔细，很认真的推敲模型'),
(1,2,'2020/6/13',1,'非常实用的课程，不会法规就不会设计'),
(3,2,'2020/6/14',0,'要记忆的东西好多啊，太难记了'),
(4,2,'2020/6/15',1,'太简单了，我考前一天看了资料，第二天考试就得了优'),
(5,2,'2020/6/16',1,'对于设计课，规范是必须要懂的'),
(1,3,'2020/6/17',0,'太难了，老师不讲中文还是有点吃力'),
(5,3,'2020/6/18',1,'还不错，老师讲英文感觉锻炼了听力'),
(1,4,'2020/6/19',1,'学了之后又能多塞几张图进排版了'),
(2,5,'2020/6/20',1,'这个脑，洗的有水平'),
(1,6,'2020/6/21',1,'雕塑很有意思'),
(6,7,'2020/6/22',1,'又学会了一种新的设计模式'),
(6,8,'2020/6/23',0,'离谱的老师'),
(9,9,'2020/6/18',1,'这个老师教的太棒了，很有收获'),
(1,9,'2020/6/19',1,'跨专业选的课，没有白选，老师水平高，不解释'),
(2,9,'2020/6/19',1,'学到了很多有用的东西，总算可以做网页了'),
(9,10,'2020/6/19',1,'闭着眼睛学的，太简单了'),
(10,11,'2020/6/19',1,'硬课，不学不是软件人'),
(5,17,'2020/6/19',1,'体验很好，下次再来'),
(6,17,'2020/6/19',1,'求求各位学霸别卷了呜呜呜'),
(7,17,'2020/6/19',1,'挺好的，就是内容有点少'),
(10,17,'2020/6/19',1,'楼上嫌内容少的，你选错课了知道吗？'),
(1,18,'2020/6/20',1,'教室的空调太冷了，睡的不舒服'),
(2,18,'2020/6/20',2,'隔壁打呼噜太吵了，睡的不舒服'),
(3,18,'2020/6/20',1,'没有小桌板来趴着，睡的不舒服'),
(4,18,'2020/6/20',0,'楼上都是公主病简直太夸张，老师这么无聊当然睡的很舒服'),
(5,18,'2020/6/20',2,'为什么要去教室睡觉,为什么不翘课'),
(5,19,'2020/6/20',1,'沙发'),
(5,20,'2020/6/20',1,'沙发'),
(5,21,'2020/6/20',1,'沙发'),
(5,22,'2020/6/20',1,'沙发'),
(5,23,'2020/6/20',1,'沙发'),
(5,24,'2020/6/19',1,'沙发'),
(6,24,'2020/6/20',10,'李四你是不是水军'),
(6,25,'2020/6/20',1,'玄学，都是玄学'),
(7,25,'2020/6/20',1,'话术，都是话术'),
(8,25,'2020/6/20',1,'套路，都是套路'),
(1,26,'2020/6/20',1,'老师和助教特别细心，手把手带进门'),
(2,26,'2020/6/20',1,'最大的困难在于软件安装'),
(3,26,'2020/6/20',1,'可是运用复杂手段得到显而易见的道理有什么用呢'),
(8,27,'2020/6/20',1,'从入门到放弃'),
(8,28,'2020/6/20',1,'选错了，下次还敢'),
(8,29,'2020/6/20',1,'老师今年转变了风格，作业量变大了'),
(9,29,'2020/6/20',1,'真好，考试占比变小了'),
(10,29,'2020/6/20',1,'水过')
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

