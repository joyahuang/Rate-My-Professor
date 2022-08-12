# Rate-My-Professor
 

 

 

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image002.jpg)同济大学

 

 

**《数据库技术与应用》**

**项目设计报告**

 

 

 

 

**项目设计报告题目：**

​       **评教综合系统**         

  **小组成员姓名** **：****__**    **申笑忧****___________**

​                                                      **__**    **何熠宽****_____________**

**__**    **黄卓雅****_____________**

**__**    **易子诺****__________**

**班级：**   袁科萍（2）      

**年级：** 15/16级 **专业：**自动化/建筑学/城乡规划 

**指导教师：**     袁科萍      

**日期：**  2020   **年** 06 **月** 19 **日**

 

 



 

目录

[1   课题设计目的和意义.................................................................................................................................................... 3](#_Toc43639282)

[2   项目需求表述................................................................................................................................................................... 3](#_Toc43639283)

[2.1   需求总述................................................................................................................................................................... 3](#_Toc43639284)

[2.2   进一步细致需求.................................................................................................................................................... 4](#_Toc43639285)

[2.3   项目的简化假设.................................................................................................................................................... 4](#_Toc43639286)

[3   关系提取与数据库实现............................................................................................................................................... 5](#_Toc43639287)

[3.1   关系的自然语言表述.......................................................................................................................................... 5](#_Toc43639288)

[3.2   E-R图与关系的抽取........................................................................................................................................... 5](#_Toc43639289)

[3.3   关系的规范化......................................................................................................................................................... 6](#_Toc43639290)

[3.4   各个关系的约束与数据类型........................................................................................................................... 6](#_Toc43639291)

[3.5   视图、触发器和存储过程................................................................................................................................ 7](#_Toc43639292)

[4   用户界面设计................................................................................................................................................................ 10](#_Toc43639293)

[4.1   整体风格................................................................................................................................................................ 10](#_Toc43639294)

[4.2   功能窗体简述...................................................................................................................................................... 10](#_Toc43639295)

[4.3   功能窗体实际展示............................................................................................................................................ 10](#_Toc43639296)

[5   演示报告.......................................................................................................................................................................... 22](#_Toc43639297)

[5.1   注册登录界面...................................................................................................................................................... 22](#_Toc43639298)

[5.2   课程广场界面...................................................................................................................................................... 24](#_Toc43639299)

[5.3   全校课程表界面................................................................................................................................................. 25](#_Toc43639300)

[5.4   个人信息界面...................................................................................................................................................... 28](#_Toc43639301)

[5.5   课程详情页........................................................................................................................................................... 33](#_Toc43639302)

[6   自我评述.......................................................................................................................................................................... 42](#_Toc43639303)

[6.1   优点和特色........................................................................................................................................................... 42](#_Toc43639304)

[6.2   缺点和不足........................................................................................................................................................... 42](#_Toc43639305)

[7   心得体会.......................................................................................................................................................................... 43](#_Toc43639306)

[7.1   易子诺..................................................................................................................................................................... 43](#_Toc43639307)

[7.2   黄卓雅..................................................................................................................................................................... 43](#_Toc43639308)

[7.3   何熠宽..................................................................................................................................................................... 44](#_Toc43639309)

[7.4   申笑忧..................................................................................................................................................................... 45](#_Toc43639310)

 



 

# 1       课题设计目的和意义

如何提升课程质量并形成良性监督，一直是高校的核心问题之一。高校课程教学的重要程度不用赘述，而学生们的意见在其中起的作用也显而易见。以同济大学为例，已有的学生评教系统虽然从一定程度上提供了“信息反馈”的途径，但是由于不对外公开，导致学生认真评教的积极性下降。再者现有的评教系统对每门课程的评教是平行进行的，课程之间并不会有比对，而比较和公开在任何督促改进系统中的地位都是非常重要，好比电影的排行，学生的荣誉榜。良性的比较可以督促教学质量不太理想的教师自我审视并改进教学方法，同时也可以让讲课很好的老师获得一些精神肯定。

另一方面，在每次选课的时候，同学们都会向学长学姐们征求意见，希望能够得到相应的选课指导显然，如果有一个软件能够实现类似豆瓣评分那样的功能，同学们上完课之后可以去到上面进行打分，以及同学们在选课的时候可以去上面参考前人留下的评价，将是非常有意义的事情。

# 2       项目需求表述

## 2.1     需求总述

根据小组讨论，软件应该拥有以下功能。

l 高分课程、低分课程以及热评课程、冷门课程的排名

l 所有课程条目的浏览

l 针对课程条目的高级查询



n 学院

n 年度学期

n 授课教师

n 课程名字

n 课程属性

n 课程评分

n 评价人数



l 特定课程的基本信息、评价与评论浏览

n 基本信息



•  课程名称

•  学院

•  授课教师

•  年度学期

•  课程属性

•  考勤占比



n 评价

•  给分

•  上课质量

•  教师热心程度

•  作业量

n 评论

l 对特定课程的评价与评论

l 快速检索同一老师的不同课程、同一学院的不同课程以及同一课程的其他班级

l 对特定课程的个人收藏

l 个人信息的管理

n 昵称

n 用户名

n 密码

n 邮箱

n 个人头像

n 收藏课程

n 其他信息

•  专业

•  学院

•  入学年份

•  培养层次

 

## 2.2     进一步细致需求

用户除了可以查看课程的各项指标的均分，还应该可以看到所有用户对各个指标评价的分布情况，并且最好是使用图例进行可视化；

用户注册的时候使用邮箱注册，登录也是使用“邮箱-密码”进行登录，系统自动为每一位用户生成唯一标识符“用户ID”；

在进行课程的排名的时候，应该可以划定范围，比如在所有土木学院开设的课程之中进行排序；

登录界面的密码最好不是明文显示，在数据库存储密码的时候亦是如此；

个人信息应该可以进行修改，包括邮箱和密码；

## 2.3     项目的简化假设

​      由于时间和精力有限，项目做出了以下简化和假设：

l 用户都是正常、无恶意的大学学生

l 一门课程只由一位老师教授

l 评论不能盖楼中楼

l 课程基本信息、教师基本信息皆已由管理员检验之后从后端导入



 

# 3       关系提取与数据库实现

## 3.1     关系的自然语言表述

​      各个用户可以浏览各个课程，用户和课程是我们的两个主体对象。用户信息有用户ID,昵称，邮箱，密码，学院，专业，入学年份，培养层次。其中后面四项可以为空。课程信息有学院、授课老师、开课学期、课程类型、课程号、给分情况、上课质量、教师热心程度、作业量、考核占比和教学大纲。用户和课程之间的事件除了浏览，还有评价、评论和收藏，它们都是多对多的关系，即一个用户可以评价、评论和收藏多个课程，一个课程也可以被多个用户评论、评价和收藏。评价的时候，各个用户给出自己的对课程的给分、上课质量、作业量和教师热心程度的评判。评论的时候，用户写出自己的想法，其他的用户可以进行点赞操作。

​      此外，老师也是一个对象。老师信息有老师编号，学院，邮箱，办公地点。其中后面两项可以为空。一个老师可以开设多门课程，但一门课程只能由一个老师开设。

## 3.2     E-R图与关系的抽取

​      根据以上信息，E-R图绘制如下：

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image004.jpg)

​      根据E-R图，可以抽离出三个对象表格——用户表格、课程表格和老师表格。

​      根据对象之间的三个多对多关系，设立三个关系表格——用户收藏课程表格，评论数据表格和评价数据表格。列写如下。

​      myUser(myuID, umail, upswd, unkname, uclg, umj, uermy, upro,upic)

​      Teacher(tID, tclg, tmail, toffice, tname,tpic)

​      Course(cID, tID, cname, cclg, csms, ctype, cppt, coutline, cscoring, ctcptc, chelp, chwl,

​                  callScoroe, cassnum)

​      myCollection(myuID, cID)

​      Assessment(myuID, cID, scoring, tcptc, help, hwl, allScore)

​      Review(myuID, cID, rdate, rlike, rtext)

*注：一些缩写对应如下

| nkname   | clg                 | mj            | ermy               | pro                  |
| -------- | ------------------- | ------------- | ------------------ | -------------------- |
| nickname | college             | major         | year of enrollment | program              |
| sms      | tcptc               | hwl           | ppt                | assnum               |
| semester | teaching competency | homework load | porprotion         | number of assessment |

## 3.3     关系的规范化

​      事实上，课程的各项得分是基于评价信息然后使用一定算法得到的，也即从某种程度上说，这是有一定的信息冗余的。但是方便起见，基于这个项目的体量，我们决定用空间换取时间，直接将得到的结果作为课程的一个属性进行保存。评价人数同理。

​      此外，用户表格中不难发现，用户所属的学院应该是传递依赖于用户ID的，因为用户的专业就可以推得其所在的学院。但是考虑到具体实现的时候，学院和专业是选填信息，可能出现类似于用户只填了学院却不填专业的情况，因此我们决定将个人信息的维护权利留给用户自己，也即忽略“学院”和“专业”之间事实存在的依赖关系。应该注意，用户的“学院”属性由用户自己维护，但是课程信息、老师信息以及各种搜索功能中的“学院”是用管理员设计的，它们之间应该保持一致。

​      此外，用户的ID完全可以替代用户名的功能，因此删去用户名属性，或者说用户ID就是用户名。

​      至此，关系的设计已经符合第三范式。

## 3.4     各个关系的约束与数据类型

| myUser       |                                                              |           |                                                              |
| ------------ | ------------------------------------------------------------ | --------- | ------------------------------------------------------------ |
| myuID        | int，主键                                                    | uclg      | char[30]，可为空                                             |
| upswd        | char[12]，英文字母、数字和特殊符号组成，不包含空格           | umj       | char[20]，可为空                                             |
| unkname      | char[20]                                                     | uermy     | char[4]，4个数字，可为空                                     |
| umail        | char[20]                                                     | upro      | char[6]，(‘本科生’,’研究生’,’博士生’,’其他’)或为空           |
|              |                                                              | upic      | image，可为空                                                |
| Teacher      |                                                              |           |                                                              |
| tID          | int，主键                                                    | tmail     | char[20]，可为空                                             |
| tclg         | char[20]                                                     | toffice   | char[40]，可为空                                             |
| tname        | char[10]                                                     | tpic      | image，可为空                                                |
| Course       |                                                              |           |                                                              |
| cID          | int，主键                                                    | Ctcptc    | float，范围1-5                                               |
| tID          | int，外键                                                    | Chelp     | float，范围1-5                                               |
| Cname        | char[20]                                                     | Chwl      | char[10]，(‘1小时以下’,’1-2小时’,’2-3小时’,’3-4小时’,’4小时以上’) |
| Cclg         | char[20]                                                     | Cppt      | char[12]，类似于“A10P00H40T50”*                              |
| Csms         | char[6]，格式类似于’2016春’’2018秋’                          | Coutline  | image                                                        |
| Ctype        | char[10]，(“公共必修课”,’公共选修课’,’专业必修课’,’专业选修课’) | callScore | float，范围1-5  整体印象分                                   |
| Cscoring     | float，范围1-5                                               | Cassnum   | int                                                          |
| myCollection |                                                              |           |                                                              |
| myuID        | int，外键，主属性                                            | cID       | int，外键，主属性                                            |
| Assessment   |                                                              |           |                                                              |
| myuID        | int，外键，主属性                                            | tcptc     | tinyint，(1,2,3,4,5)                                         |
| cID          | int，外键，主属性                                            | help      | tinyint，(1,2,3,4,5)                                         |
| scoring      | tinyint，(1,2,3,4,5)                                         | hwl       | char[10]，(‘1小时以下’,’1-2小时’,’2-3小时’,’3-4小时’,’4小时以上’) |
|              |                                                              | allScore  | tinyint,(1,2,3,4,5)  整体印象分                              |
| Review       |                                                              |           |                                                              |
| myuID        | int，外键，主属性                                            | rlike     | int                                                          |
| cID          | int，外键，主属性                                            | rtext     | char[100]                                                    |
| rdate        | date                                                         |           |                                                              |

*“A10P00H40T50”指出勤(Attendance)，小组报告(Presentation)，作业(Homework)，考试(Test)分别占比10%, 0%, 40%, 50%.

 

​      进一步，出于节约空间的考量，一些限定了范围的字符串属性可以用字符来代指。

| 属性     | 原约束                                                       | 新约束                             |
| -------- | ------------------------------------------------------------ | ---------------------------------- |
| upro     | char[6]，(“本科生”，”研究生”，”博士生”,”其他”)或为空         | char[1]，(“1”，”2”，”3”,”4”)或为空 |
| ctype    | char[10]，(“公共必修课”，”公共选修课”，”专业必修课”，”专业选修课”) | char[1]，(“1”，”2”，”3”，”4”)      |
| hwl/chwl | char[10]，(“1小时以下”，”1-2小时”，”2-3小时”，”3-4小时”，”4小时以上”) | char[1]，(“1”，”2”，”3”，”4”，”5”) |

 

## 3.5     视图、触发器和存储过程

### 3.5.1    视图

根据需要，一共创建了4个视图，视图名字、属性和用途如下：

| StaticCourse  用于结合课程信息和老师信息形成课程条目      | cid                                                 | 用于检索对应课程                |
| --------------------------------------------------------- | --------------------------------------------------- | ------------------------------- |
| cname                                                     |                                                     |                                 |
| cclg                                                      |                                                     |                                 |
| csms                                                      |                                                     |                                 |
| ctype                                                     | 根据对应规则从字符转成文字，比如”1”转成”公共必修课” |                                 |
| callScore                                                 |                                                     |                                 |
| cassnum                                                   |                                                     |                                 |
| cscoring                                                  |                                                     |                                 |
| ctcptc                                                    |                                                     |                                 |
| chelp                                                     |                                                     |                                 |
| cppt                                                      |                                                     |                                 |
| chwl                                                      | 根据对应规则从字符转成文字，比如”1”转成”1小时以下”  |                                 |
| tid                                                       |                                                     |                                 |
| tname                                                     |                                                     |                                 |
| hotCourse  视图一共20条，形成热门排行榜，即评论人数最多的 | 属性同上                                            | 按照cassnum属性，从高到低排序   |
| redCourse  视图一共20条，形成红榜，即分数最高的           | 属性同上                                            | 按照callScore属性，从高到低排序 |
| hotCourse  视图一共20条，形成黑榜，即分数最低的           | 属性同上                                            | 按照callScore属性，从低到高排序 |

 

### 3.5.2    触发器

​      设置了一个触发器*calculating*用来更新课程的各个得分属性，挂在Assessment表下。评价是一条条增加的，每增加一条评论，就需要进行一次相应的计算，然后把计算结果更新到Course表中对应课程条目的属性之中。

| 所用参数         | inserted.cID             | 获取是哪一门课程增加了评价 |
| ---------------- | ------------------------ | -------------------------- |
| 改动参数         | Course.cscoring          | 取新的该课程该属性总均分   |
| Course.ctcptc    | 取新的该课程该属性总均分 |                            |
| Course.chelp     | 取新的该课程该属性总均分 |                            |
| Course.chwl      | 取新的该课程该属性总众数 |                            |
| Course.callScore | 取新的该课程该属性总均分 |                            |
| Course.cassnum   | 该课程该属性加一         |                            |

 

### 3.5.3    存储过程

​      设置了一个存储过程*getReview*用来得到评论区的显示数据。该存储过程有一个入口参数。

| 入口参数 | @_cID | int  |
| -------- | ----- | ---- |
|          |       |      |

​      用户在前台查看某一条具体课程信息页面时，前端会将所查看的课程cID传给数据库并调用存储过程。存储过程根据课程号，生成评论区的显示数据，所需要的数据列表如下。

| Review | cID                       | cID = @_cID |
| ------ | ------------------------- | ----------- |
| rdate  |                           |             |
| rlike  | 按照rlike从高到低排序     |             |
| rtext  |                           |             |
| myuID  | myUser.myuID=Review.myuID |             |
| myUser | unkname                   |             |
| upic   |                           |             |

​      



 

# 4       用户界面设计

## 4.1     整体风格

​      一个好的软件，必定要有一个好的UI。我们的设计思路有两条主旨：

​      1、通过各种交互和设计能够向用户直接展示操作逻辑；

​      2、选色美观，设计应具有活力风采，让人心情愉悦。

## 4.2     功能窗体简述

| 登录相关                  | 登录login                                          | 用户登录                                           |
| ------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| 注册registration          | 用户注册                                           |                                                    |
| 主界面                    | 主窗体MainForm                                     | 登录后显示的窗体，一个容器，最主要的页面           |
| 广场Square                | 一个tabControl容器，进行三个榜单的切换             |                                                    |
| 红榜Red                   | 分数最高20门课程的展示                             |                                                    |
| 黑榜Black                 | 分数最低20门课程的展示                             |                                                    |
| 热门课程Hot               | 评价人数最高20门课程的展示                         |                                                    |
| 全校课程StaticCourse      | 所有课程在此罗列，可以高级筛选                     |                                                    |
| 个人信息Person            | 所有用户个人信息在此罗列                           |                                                    |
| 修改头像alterPhoto        | 修改个人头像                                       |                                                    |
| 修改密码alterPassword     | 修改个人密码                                       |                                                    |
| 修改信息alterInfo         | 修改个人其他信息                                   |                                                    |
| 个人收藏Collect           | 个人收藏的课程在此罗列                             |                                                    |
| 课程信息与评价相关        | 课程信息courseInfo                                 | 某一门具体课程的所有信息展示                       |
| 课程大纲courseSyllabus    | 某一门具体课程的大纲在此展示，图片形式             |                                                    |
| 评价分布图diagram         | 某一门课程各项评价的分布在此展示                   |                                                    |
| 评论区ReviewArea          | 一个容器，所有评价在此展示，或者“暂无评价”在此显示 |                                                    |
| 暂无评论显示图NoRreview   | 如果没有评论数据，则评论区显示此窗口               |                                                    |
| 评价窗口coursesEvaluation | 用户对某一门课程评价的窗口                         |                                                    |
| 评论窗口coursesComment    | 用户对某一门课程评论的窗口                         |                                                    |
| 教师信息teacherInfo       | 教师信息即其他开设课程在此罗列                     |                                                    |
| 其他                      | 全局信息VitalMessage                               | 全局使用的变量在此定义，即用户ID和数据库链接字符串 |

## 4.3     功能窗体实际展示

### 4.3.1    登录相关

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image006.jpg)

登录

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image008.jpg)

注册

 

### 4.3.2    主界面

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image010.jpg)

主窗体，容器，其中已经显示了广场容器（热门、红榜、黑榜）和热门课程

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image012.jpg)

红榜

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image014.jpg)

黑榜

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image016.jpg)

全校课程及各种筛选按钮

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image018.jpg)

个人信息，其中已经包含了个人收藏

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image020.jpg)

修改头像

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image022.jpg)

修改密码

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image024.jpg)

修改信息

 

### 4.3.3    课程信息与评价相关

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image026.jpg)

课程信息，其中已经包含了评价分布图和评论区

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image028.jpg)

课程大纲，此处用随意的一张图片表示

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image030.jpg)

评价窗口

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image032.jpg)

评论窗口

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image034.jpg)

暂无评论显示图

![img](file:////Users/zhuoyahuang/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image036.jpg)

教师信息



 

# 5       演示报告

## 5.1     注册登录界面

![img]()

![img]()
 进入系统后是注册、登录界面。

注册界面的前三项“邮箱”、“密码”、“昵称”分别对应myUser中的umail, upswd,unkname三个not null的列。其中邮箱不能为已注册的邮箱；密码不应有空格，长度应为8-12位。注册成功后蹦出“注册成功”的提示信息，并关闭注册窗口，在登录窗口继续。

 

![img]()
 登录时，首先判断邮箱是否存在，若不存在，清空邮箱和密码的textbox；若存在，判断密码是否正确，错误则清空密码的textbox。

 

 

 

![img]()

## 5.2                     ![img]()      课程广场界面

登录成功后进入首页学生广场，学生广场界面对应导航栏的红色按钮（HOT/FIND HOTTEST COURSES），以瓦片（TileView）形式展示热门（评论数由高到低）、红榜（总体印象分由高到低）、黑榜（总体印象分由低到高）的前20个课程，三个榜单通过tab进行切换。通过鼠标悬浮在瓦片上时蹦出来的“查看详情”按钮，或双击该瓦片选择感兴趣的课程，蹦出该课程详情页面。

 

## 5.3     ![img]()全校课程表界面

点击导航栏的绿色按钮（COURSE/COMPULSORY&OPTIONAL）进入全校课程表界面。该界面通过列表（GridView）的方式显示所有课程的详细信息，用户可以进行分类、分组、筛选、查询、排序等交互功能，单击课程行可进入该课程详情界面。

 

 

 

 

 

 

 

![img]()

![img]()

## 5.4     ![img]()  个人信息界面

点击导航栏灰色按钮（PERSON）进入个人信息界面，界面分为三个部分。账号信息显示头像、昵称、密码，可以通过鼠标点击头像进入修改头像页面，点击修改密码按钮进入修改密码界面。个人信息显示学院、专业、入学年份、培养层次，这几项为注册时的选填信息，用户可以通过点击修改信息进行更新。收藏课程界面以卡片（CardView）形式显示用户收藏课程，点击课程卡片可进入课程详情页。

 

### 5.4.1    修改头像页面

用户点击选择头像后进入文件对话框，若文件对话框点取消或未选择新头像直接确定，会出现“未选择图片”提示信息。成功选择图片文件后，在右侧Picturebox中显示，点击确定后在个人信息页面中更新。

![img]()

 

 

 

### 5.4.2    修改密码页面

![img]()
 修改密码页面首先判断原密码是否正确，若错清除原密码对应的textbox；再判断新密码是否符合规范，最后判断两次输入密码是否一致，若错则清除新密码和二次输入密码对应的textbox；若符合要求则更新数据库。

### 5.4.3    修改信息页面

修改信息页面下各信息默认的初始值为用户原信息，用户可进行修改，点确定提交。

![img]()

 

### 5.4.4    收藏课程

用户可通过Customize按钮对卡片显示的条目进行个性化显示。勾选卡片中想要显示的课程信息，如取消勾选课程编号；对课程信息进行分类筛选和按值筛选，如给cclg加filter筛选开课学院为“建筑与城市规划学院”的课程，给scoring加filter筛选得分在1-4的课程。

![img]()

 

 

 

 

![img]()

## 5.5     ![img]()  课程详情页

课程详情页有四个部分。基本信息模块中点击任课老师可显示该老师的基本信息和开设课程；考核占比模块是静态的显示；评价信息显示各打分项的平均值，点各项得分会在右侧显示该项的评价分布；评论区以点赞数由高到低的顺序显示各位同学的发言。

课程详情页有四个按钮。课程大纲按钮会在新窗体显示大纲图片；收藏课程按钮，如果该用户还未收藏该门课程，点击就会加入收藏按钮变灰，若已收藏则该按钮不可用；我要评价按钮，如果该用户还未评价该门课程，点击后在新窗体显示评价页面供用户填写，提交后按钮变灰，若已评价则该按钮不可用；我要评论按钮，如果该用户在该天还未评论过，点击后在新窗体显示评论页面供用户填写，若该天已经评论则该按钮不可用。

 

### 5.5.1    教师信息页面

教师信息页面显示该教师的基本信息、图片和开设课程。

其中，开设课程以瓦片（TileView）形式排列，用户可通过鼠标悬浮在瓦片上时蹦出来的“查看详情”按钮，或双击该瓦片选择感兴趣的课程，蹦出该课程详情页面。

![img]()

 

### 5.5.2    ![img]()  课程大纲页面

 

### 5.5.3    课程评价页面

用户可用过鼠标Hover来点亮各评价星级，全部填写完整后点击提交进入数据库，并在课程详情页更新评价数据，使我要评价按钮变灰。

![img]()

 

![img]()

 

 

 

 

### 5.5.4    课程评论页面

课程评论页面控制填写字数在2-100之间，少于2影响评价质量，多于100进不了数据库。

![img]()

![img]()

 

 

|      |          |
| ---- | -------- |
|      | ![img]() |







### 5.5.5    评价信息

鼠标点击各项的平均评价分数，右侧的可视化界面会自动更新为该项的分数分布。如8个人给该课程的总体印象分打了5分，1个人打了1分；7个人给该门课程的给分打了5分，1人打了3分，1人打了1分。

![img]()

 

![img]()

 

![img]()

 

![img]()

 

![img]()

 

 

 

### 5.5.6    评论区

![img]()
 如果该门课程暂时没有评论，则显示鼓励用户评论的信息。

如果该门课程有评论，则评论区以点赞数由高到低显示该门课的评论。用户可以鼠标Hover各评论进行点赞，点赞后评论区会更新。如，李五同学初始点赞数为1，该用户点了多次赞后，李五以6个攒冲上第一位。

![img]()

![img]()



 

# 6       自我评述

## 6.1     优点和特色

·    界面美观，设计感十足，充满青春活力

·    配有一定的动画和图标，交互逻辑设计合理清晰，使用者能够快速入手

·    评价指标全面，充分展示课程质量

·    充分利用第三方插件，提高生产力

·    配套功能全面，已达到实际运用需求层面

## 6.2     缺点和不足

·    未能纳入多门老师开设一门课程的情况

·    未能为导入课程数据、教师数据等也设计配套的前台窗体

·    未能加入管理者角色，没有实现清理不合理评论与评价的功能

·    加载有些迟缓



 

# 7       心得体会

## 7.1     易子诺

回想起整个流程，最大的分歧就是出现在一开始，敲定项目到底要做什么的时候。其实我们都有一些结合专业的新奇想法，但是他们都比不过评教系统，因为我们4个对选课的时候没有参考这种痛苦的体会太深、太有共鸣。也许是4、5年的学习一直都受其限制，以至于可以亲手实现一个满足自己幻想的评教系统是如此地令我们兴奋和充满动力，即使我们都知道它并不会真正上线应用，而且肯定有很多前人已经做过尝试了。哪一个在同济学习的学生没有幻想过一套可以查询往年评价、拥有对好的课程夸奖对差的课程吐槽的评论区、还可以像微博热搜榜一样对课程进行排名的评教信息系统呢？所以我们最后决定，还是做评教系统吧。

​      此外，自己提出需求，自己分析需求，自己提取关系一直到前端的实现，这个过程魔幻且充满魅力。不同于在设计一些智能车之类的专业课程，这个项目如此地贴近生活和痛点，以至于我们在做的时候会不断地带入用户的角色，并基于自己以往在使用各种软件的时候所关注到的用户友好的设计或是不友好的缺点，对我们的项目不断提出“苛求”。虽然最后在反复权衡之下，并非所有“苛求”都得到了实现，但是这种自己DIY的过程，就好似饱受食堂难吃饭菜的学生，在学习烹饪之后，根据知识和经验重造了食堂的“番茄炒蛋”，并且发现自己真的能做出来而且味道还不错的那种满足和兴奋感。

​      实现的细节自然是有很多磨难小故事，提高了数据库的C#开发平台的应用能力当然也不会缺少，但翻来覆去且难以共鸣，此处不多赘述。但必须提及的一点就是神仙队友们，他们强大的计算机能力和学习能力震惊了我，使我一改偏设计类专业的朋友不懂编程的刻板印象。每个人都非常负责任且善解人意，礼貌且闪耀着智慧的光芒。回顾大学4年生涯，此次组队体验应该保二争一了。

​      最后，在计算机素养和编程能力几乎成为了大学生必备技能的21世纪，我又学习到了一门关键且重要的计算机课程——数据库，对此我表示很开心。

## 7.2     黄卓雅

五年来沉浸在人文艺术社科政治之中，第一次在毕业季这个放飞自我的学期斗胆选到这么硬核的计算机课程，课程干货满满，从无到有收获巨大。

我在大作业的重心在于课程详情页及其附属页面的前台实现。选取了DevExpress控件库，因其扁平化风格和多样的属性功能可以减轻很大的代码量。这个学习和实现的过程十分熬人，由于网上信息量较少只能对着开发文档学，碰上了Bug也不知道怎么解，这对我挑战巨大，但我比较闲所以还是花了时间把项目中用到的控件艰难地实现了。同时，我也承担了对合并后整合测试的细节工作，一点一点看着最终项目能动起来，真的非常有成就感。

我的队友们给予我很大的启发，大佬们的脑子真的很好用，他们在整个项目推进进程中思路十分清晰明确并具有极强的领导力，跟着大佬们熟悉业务的过程十分快乐；我第一次经历从选题到需求分析到界面设计到分工的小组大项目全过程，这与规划设计的小组讨论完全不同，每次讨论之后都让我对计算机类的项目管理有了全新的认识。我十分敬佩我的队友们都有想法并为之付出努力，愿我们都有美好的未来。

整个课程学习中间投入了很多精力。由于技术背景薄弱，对于各类抽象名词和术语的概念理解十分困难，面向对象语言也要重头学习，做作业时需要花更多的时间，这也极大的锻炼了我自主学习、解决问题技能。课程内容很充实，老师讲课十分细致拓展丰富，既可以学数据库还可以做大项目，一门顶两门，是我所有280个学分当中，学费交的最超值的一门。

## 7.3     何熠宽

昨日答辩，袁老师说的两件事让我挺有感触。

首先是项目选题，现在回看的确有遗憾，这是一种取舍：课程评教系统是常规安全的，有切身体会的，只需要改进而不需要大创新的，主要精力在打磨技术，做一个好看好用的产品。而课程所期望的将数据库技术和自身专业所需进行结合的项目，是有风险的，有思维创新难度的，可以不精致，重点在概念模型。可以说这两者的侧重点不同，我现在思考下来，的确可以解释说我们希望通过项目把整个技术练的纯熟，因为时间不够等种种因素选择降低创新方面的难度，而专注于产品的完善性。实际上关键的问题是，如果不能学以致用，那么技术本身有什么用呢？这门课的出发点应该是将技术用于自己专业领域，如果不能时时刻刻思考结合点，那么就要去和码农比技术，如果想成为码农那倒没关系。这让我想到另一件事，某个创新论坛，我们组开发了一套古建筑病害管理系统，另一个组是校园服务的程序。当时他们羡慕我们：“你们有实体的东西，可以和专业进行结合。“我那时不是很明白，因为他们做的非常精美，考虑全面好用。如果把自己定位为交叉型的人，最可贵的是结合的能力，贴近生活的产品当然有无数的创新点，但是这是一种更广泛的能力，你不确定对此是否敏锐，所以大部分人可以做，会去做。

第二件事是老师提到退课的事。在毕业关头的我十分能理解，大部分大二大三的同学都需要计算，GPA是指挥棒，也许不太能纯粹的学习。一种角度来看，数据库这门课知识含量大，负担重一些，不是必修的话，很多人不敢选。另一种角度来看，可能真因为上了某门课，人生的选择就会很不一样，这么说的价值会远大于那一点点的GPA。反过来映射到了我们选题的事，可能确实有点保守，往往好的东西就在挑战中诞生，就差一些冲劲，之后应该少一些计算，少一些求全的心态，多一些极致的追求。

回顾整个项目，技术之外的收获远大于具体技术细节。很多事没经验的话，即使有意识也很难做好，这次是迈出第一步。第一件事是全流程把控，包括时间节点，每部分如何合作，对可能风险的提前预估。在确定选题后，我就隐隐意识到编码部分应该往后移，意味着前期要把共同的东西讨论确定下来，才能进行科学的任务拆分，分配到每一个人。尤其是在发现devexpress插件后，编码部分内容进一步下降，所以更重要的是需求讨论清楚，具体确定有哪些页面，操作流程，数据库有哪些表，甚至要到UI设计，这样写代码的工作其实所剩不多。这是当时前瞻的想法，5.24开始到6.10，我们进行了五次集体讨论，把上述事情敲定。

现在看得到几个经验，如果团队没有经验，那么不能想着“顶层设计“，因为将会出现的问题是不可预料的。最好的办法应该是简单设计，快速做出原型，再来重构迭代。举一个简单的例子说明，一开始我在考虑如何拆分任务以进行分工时，面前有两条路：1.纵向切分，每个人都涉及全流程的一部分；2.横向切分，每个人负责相对独立的一部分，比如a数据库，b整个ui设计，c写界面代码，d.测试，完善，报告等。当时的判断是，第二种对于完成项目本身更科学，第一种对于学习过程更好，都得到了锻炼。现在的想法是，第二种需要有经验的团队才能做，而且需要总体控制的负责人。实际上我们后来是第一种。我给出最初最简陋的数据库表，易根据后来的需求彻底重构完整了整个数据库。经过拆分，我把三个大界面（功能简单）的UI布局考虑好，黄去写最难的几个弹出页面，申解决技术难点。然后我和申根据前端调用的需求重新过了一遍数据库，修改了表的小错误，添加了需要用的视图。然后再回过头来各自写了几个页面，黄和易那边也在根据页面所需修改数据库，申负责几部分的合并及解决出现的问题。所以这样看下来，其实每个人的部分都需要从前端到后端的了解，那么按照前面的经验，快速写出一个粗糙的版本，实际上让每个人对此有经验，哪里有坑哪里要完善心中有数，这样再迭代一版就方便的多。

另一个经验是，插件是把双刃剑，一开始我过于盲目的相信devExpress能解决很多问题，实际上它也带来了问题。它能实现的效果，用winform自带控件也能实现，这是对基础功能和代码的锻炼。而对devexpress的了解耗费了非常多的时间，因为不熟悉。这让我意识到，如果选择一套全新的工具，那么首先要判断的是，之后我会不会长时间用它，如果不会，那么没有必要花很多时间研究它。对于框架要有审视的态度，毕竟太多了。

前面说的是每个人各部分都要有所了解，另一个经验却是不能求全。我最开始惯性思维是想对所有部分都熟悉掌控，不然不安心。这犯了几个错误。合作的目的就是每个人负责一部分，个人的精力是有限的。另一个点就是写代码的盒子思维，我不太需要知道实现细节，相信内部的实现，只需要知道接口，输入输出是什么即可。毕竟每个项目能锻炼的点是有限的，把握到自己那几个点就应该满足了。

还有一些实现的细节体会，界面设计等收获，就不在此展开了。总的来说对还是挺满意的，在大家都没有很多经验的情况下，和队友合作的很愉快，都很负责。老师的教学方式我也很认可。最深印象的是，和同学讨论实验报告，上课时刻解答问题，以项目实验为主导的学习。

 

 

## 7.4     申笑忧

虽然我们此次做的项目没有与专业相结合，技术有余而创新不足，但是作为我第一次参与的合作型软件项目，还是让我收获颇丰，给了我很多感悟。

1.小组合作

我们做的并不是什么大项目，也不涉及多复杂的工序，但是在整个项目之中我们可能花了一半甚至是以上的时间用来确定框架性的东西。因为期末的项目和论文多，我希望能迅速开始，迅速解决这个问题，甚至觉得花费过多的时间用来讨论这些东西，会不会导致时间不够。

我其实知道软件工程的时间花费是架构60%，功能实现20%，代码20%，我自己写项目的时候也是这样的习惯，代码的难度在于debug，至于代码本身一般都是没有难度的，前期规划的好，代码的bug也会很少，后期耗费的精力小。

那么问题的关键其实是在掌控感，我自己的项目我可以掌控，但是我缺乏对于合作项目的掌控感，而且前几次会议都未能够系统明确我们要做的东西，一直导致这个项目在我的眼中处于一个未知状态，摸不着底。是的，我前期没有“预期”。预期与共识是合作事务之中最关键的东西，只有大家对项目拥有预期和共识，才能够放心的放开手做，否则会平白无故增加交流的心理负担。

现在回想起来，我觉得新小组开始合作，最重要的事其实是确定好时间进度的规划，对于任务时间进行规划和确定，然后大家就知道目前所处的阶段，然后下一阶段是什么。当然，最开始的时候，项目都没有产生，时间规划肯定很粗略可信度不高，但是，不能没有这个东西，否则就不能进行正确的时间定位。

总体来说，这次小组合作是目前对我最有启发的一次了，我感觉到下一次项目合作我会更加得心应手，在此感谢诸位大佬带飞！

2.查询的速度是快速学习，快速应用的关键

在此次的实践之中，为了谋求更好的表现效果。（这也是我们建筑与规划的学生的特点，很多时候我们都相信，这个世界是“看脸”的。）我们选择使用新的插件devexpress，使用它里面的控件。它也为我们减小了很多代码的工作量，但是学习的时间和成本也上去了。现在想起来，这个插件其实很好用，现在回过头去看，做项目过程之中遇到的问题也叫问题？有什么难度？

但是，掌握一个工具最难的时候就是它的各种信息还未知的时候，一旦它的基本框架从未知变成已知，查询花费的时间从未知变成可预期时间，那么难度就会呈现断崖式下降。学习新的东西，查询能力是最重要的能力，能够通过查询解决未知的错误，不会的使用方法。掌握了查询能力，实际上就掌握了学习能力的70%以上。

但是查询不会的东西不是一个简单的事，特别是连问题都摸不着头脑的时候（处理知道关键词的问题是很简单的，但是真正难的地方在于，如果连要搜索的东西，关键词都理不出来，这就困难了）。从语义的角度来看查询，在哪里查询，查询什么关键词？都是问题。为了解决这个问题，和操作系统的虚拟内存的多级页表很像，有一个页目录，然后才是真正的页表，而使用页表的地址才能够在存储器之中找到需要的东西。同样的，学习一个新的东西的时候，我觉得花费一定的时间去了解这个东西的框架知识，也就是它由哪几个部分组成，然后每一部分是承担什么功用，很重要。有了框架之后，不需要继续细致的学习，在遇到问题的时候，就可以迅速确定问题在哪一块，怎么继续往下搜索。

上面的搜索方法都仅仅是使用搜索引擎的方法，其实最有效的方法是询问人，问懂的人是最有效的方法，一个内行的人，要么能够快速提供解决方法，要么能够快速指点明路，在学习过程之中，人是最有效的信息源，在某些场合下，需要鉴别人的语言的有效性，但是在技术问题上，问题通常是能够迅速得到指点的，有效无效一目了然。人是最宝贵的信息源。

3.选题

最开始我并未认识到选题与专业结合的必要性，我确实是认为选课系统对于我十分有用，上学期选设计课老师，不慎选错了老师。老师的指点风格与个人的学习方式完全不符合，而且不会理会学生的意见，那是我大学以来最痛苦的一个学期，方案直到期末都还是被否定，以至于我们本来三个组，有两个组去请别的老师指导。当时我就想，如果有一个地方能够问到老师的教学风格，那么对于我这样需要这种信息的学生来说就太有帮助了。

不过，这种工具现在市面上确实十分多见。如果是真的打算把这个东西落到实处，那么我相信这个项目也不是说因为常见没有创新就不好，能够给学校的学生提供真实的帮助，无论这个工具多么老旧我也喜欢这个工具。然而问题的关键在于，我们做的是一个课程项目，远远达不到实际使用的功能。在课程项目之中，最关键的可能确实是创新性，探索技术的新的使用方式，而与专业结合是最实在的创新。这是选题中遇到的问题，对于我个人而言，我觉得我们的选题没问题，对于我个人很需要，我甚至在想，这个东西难道真的不可以变成一个实际运作的东西吗？或许以后我学习网页的知识，然后真的租了一个服务器又把现在的代码转译过去，然后搭建一个大家都能用的选课信息系统，第三方管理，不受学校监管，大家提供真实有效的信息。（美好的愿景）

 
