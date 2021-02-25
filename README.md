# Course-Management-System
&emsp;  
# 目录
> ## **[项目结构](#First)**  
&emsp; 
> ## **[程序说明与实现](#Second)**  
>> ### [数据结构](#Second-1)  
>> ### [程序实现](#Second-2)
>> ### [库功能说明]](#Second-3)
&emsp; 
> ## **[MRX与MRI文件](#Third)**   
>> ### [MRX](#Third-1)  
>> ### [MRI](#Third-2) 
&emsp;  
## <span id="First">项目结构</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  如下图所示为课程管理系统的程序结构图，主要包含<kbd>用户框架</kbd>与<kbd>服务框架</kbd>两部分。**服务框架**用于程序的文件管理，存在于命名空间 `MRsystem` 下，包含*MRI*文件与*MRX*文件的操作方法；**用户框架**用于提供程序的数据处理部分，用于整合老师、学生和课程的数据，并交由不同的界面进行显示。  
![课程管理系统程序结构图-(READMEIMG/CMS-Struct.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-Struct.png)  
&emsp;  
## <span id="Second">程序说明与实现</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;课程管理系统采用C\#基于<b>.Net Framework</b>平台实现，版本号为<b>4.7.2</b>，因此需要系统提供NFW支持。下面将对程序的**数据结构**与具体的**实现**进行说明。  
### <span id="Second-1">数据结构</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在程序的实现中，输出部分使用[MRX](#Third-1) 和[MRI](#Third-2) 文件，因此这部分内容参考对应节。  
+ **学生/教师关系**  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;学生/教师关系保存在课程关系表中，**课程关系表**的结构如下图所示。课程使用*二叉排序树*进行保存，保证查询时的效率。  
![课程管理系统课程关系表-(READMEIMG/CMS-Class-Relation.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-Class-Relation.png)  
&emsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在每一个课程中，都包含一个复合链表，最外层链表保存<kbd>教师ID</kbd>，每个教师ID之后还保存<kbd>学生ID</kbd>和<kbd>学生数</kbd>。每个课程都拥有自己的<kbd>ID</kbd>、<kbd>名称</kbd>、<kbd>简介</kbd>和<kbd>学分</kbd>等参数，保证不会出现重复课程与选课超员的问题。
&emsp;  
+ **课程成绩**  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;课程成绩保存在**学生信息树**中，其结构如下图所示。学生信息树采用*二叉排序树*进行保存。  
![课程管理系统学生信息树-(READMEIMG/CMS-Student-Tree.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-Student-Tree.png)  
&emsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;每一个学生节点都以<kbd>学生ID</kbd>作为索引，包含<kbd>学生姓名</kbd>、<kbd>年纪</kbd>、<kbd>学院</kbd>、<kbd>专业</kbd>和<kbd>课程信息</kbd>。课程表中保存已选的课程编号与教师编号，同时还保存了课程的分数。整个课程表是一个排序的单向链表。
&emsp;  
+ **教师信息**  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;教师的信息保存在**教师信息树**中，其结构如下图所示。教师信息树采用*二叉排序树*进行保存。  
![课程管理系统教师信息树-(READMEIMG/CMS-Teacher-Tree.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-Teacher-Tree.png)  
&emsp;  
### <span id="Second-2">程序实现</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;课程管理系统在程序方面分割为了**登录程序**与**实用程序**。  
#### **登录程序**
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;以 `output` 文件夹的程序为例，**登录程序**为`课程管理系统.exe`，**实用程序**为`ClassOptions.exe`。**登录程序的逻辑流程**如下图所示。  
![课程管理系统登录逻辑流程-(READMEIMG/CMS-Signin-Logic.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-Signin-Logic.png)  
&emsp;  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;登录程序会在启动之前完成程序必须的插件检测，如果缺少必要插件将会抛出异常。之后加载登录数据文件并完成密码验证（*当前程序未加入加密算法，保存文件为明码*），之后根据登录用户说明符表明用户身份。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;登录成功后，登录程序将通过传递参数启动实用程序，并结束登录程序。
&emsp;  
#### **实用程序**
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;登录程序验证完成后将会向实用程序传递启动数据，并启动实用程序。**启动参数说明**如下图所示。  
![课程管理系统登录逻辑流程-(READMEIMG/CMS-MainPro-StartParam.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-MainPro-StartParam.png)  
&emsp;  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;实用程序根据参数`Teacher`、`Student`和`Control`分别启动对应的界面，避免出现功能冗余的问题。  
+ 教师界面  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**教师界面**主要提供教师个人信息的修改以及修改学生的分数的功能，如下图所示为**教师主界面**。    
![课程管理系统教师主界面-(READMEIMG/CMS-UI-Teacher-Main.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Teacher-Main.png)  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;主界面中包含当前教师的所有教授课程信息，包括当前选择该老师课程的**学生人数**。
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;进入课程中之后的**教师课程详细信息**如下图所示。其中包含选择的学生信息以及对应的分数。    
![课程管理系统教师课程详细信息-(READMEIMG/CMS-UI-Teacher-Class.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Teacher-Class.png)  
> 

+ 学生界面  
> **学生界面**主要包含当前学生的信息，包括已选课程和待选课程。**学生主界面**如下图所示。    
![课程管理系统学生主界面-(READMEIMG/CMS-UI-Student-Main.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Student-Main.png)  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;已选课程界面如下图所示，可以在该界面中查看当前已选课程的信息以及课程的成绩。    
![课程管理系统学生已选课程界面-(READMEIMG/CMS-UI-Student-Selected.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Student-Selected.png)   
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;待选课程界面如下图所示，在待选课程中，将会展示当前可选的课程信息；同时还可以根据年级、学分、教师搜索课程。    
![课程管理系统学生待选课程界面-(READMEIMG/CMS-UI-Student-Unselect.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Student-Unselect.png)   
> 

+ 教务界面  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**教务界面**如下图所示，主要提供**课程**、**教师**和**学生**的管理工作。    
![课程管理系统教务界面-(READMEIMG/CMS-UI-Control-Main.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Control-Main.png)   
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;主界面中主要包含四部分，分别是**添加**、**课程管理**、**教师管理**和**学生管理**。**添加界面**如下图所示，主要用于添加课程、学院、教师和学生。    
![课程管理系统教务添加界面-(READMEIMG/CMS-UI-Control-Add.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Control-Add.png)   
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如下图所示为**课程管理界面**，主要用于**修改课程信息**、**分配教师**和**强制选课**等操作。    
![课程管理系统教务课程管理界面-(READMEIMG/CMS-UI-Control-Class.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Control-Class.png)   
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如下图所示为**教师管理界面**，用于管理教师信息。    
![课程管理系统教务教师管理界面-(READMEIMG/CMS-UI-Control-Teacher.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Control-Teacher.png)   
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如下图所示为**学生管理界面**，用于管理学生信息。    
![课程管理系统教务学生管理界面-(READMEIMG/CMS-UI-Control-Student.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-UI-Control-Student.png) 
>   

&emsp;  
### <span id="Second-3">库功能说明</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;课程管理系统中，为了降低模块的关联度，将不同的文件、数据操作进行了分离。下表将对对应应用程序扩展库、应用程序和文件进行功能性说明。  
|文件名|路径|说明|
|:-:|:-:|:-:|
|`AbMessage.dll`|`ROOT\`|帮助信息面板|
|`ClassManageSystem.Classes.dll`|`ROOT\`|课程信息操作工具类（包含课程信息数据结构）|
|`ClassManageSystem.dll`|`ROOT\`|管理工具基础类（包含数据定义）|
|`ClassManageSystem.Students.dll`|`ROOT\`|学生信息操作工具类（包含学生信息数据结构）|
|`ClassManageSystem.Teachers.dll`|`ROOT\`|教师信息操作工具类（包含教师信息数据结构）|
|`ClassOption.UI.dll`|`ROOT\`|课程管理系统GUI库|
|`ClassOptions.exe`|`ROOT\`|实用程序（必须由`课程管理系统.exe`启动）|
|`MRsystem.Collections.dll`|`ROOT\`|文件操作工具类|
|`MRsystem.Collections.MRI.dll`|`ROOT\`|MRI文件类|
|`MRsystem.Collections.MRX.dll`|`ROOT\`|MRX文件类|
|`MRsystem.dll`|`ROOT\`|文件操作核心库|
|`MRsystem.Exception.dll`|`ROOT\`|文件操作异常库|
|`UserTool.dll`|`ROOT\`|用于`课程管理系统.exe`的工具库（包含UI）|
|`课程管理系统.exe`|`ROOT\`|登录程序|
|`ClassManage.mrx`|`ROOT\bin\`|课程信息文件（包含教师、课程和学生信息）|
|`ClassManageSystem.mri`|`ROOT\bin\`|课程管理系统配置文件|
|`PersonManage.mri`|`ROOT\bin\`|课程管理系统登录信息文件（未加密）|
|`NETABOUT.pdf`|`ROOT\About\`|.Net Framework描述文件（可不存在）|

*注：`ClassManage.mrx`、`PersonManage.mri`以及`ClassOptions.exe`的路径可通过课程管理系统配置文件（`ClassManageSystem.mri`）修改。*

&emsp;  
## <span id="Third">MRX与MRI文件</span>
### <span id="Third-1">MRX</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MRX文件模板参考***XML***文件，但进行了整体的修改，其模板如下所示：
```
MRX头：
    <!mrx version=1.0.0.1 encode="utf-8" mode="automode" lang="English"/!>
目录：
    <Entry name="">内部可以包含多个目录、键和注释</Entry>
普通键：
    <Key name="" type="">参数值</Key>
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<kbd>MRX头</kbd>用于描述当前文件的MRX版本号、编码方式、加载模式和适用语言。MRX版本号当前固定为1.0.0.1；**编码方式**包含：<kbd>GB2312</kbd>、<kbd>UNICODE</kbd>,<kbd>UTF8</kbd>和
<kbd>ASCII</kbd>四种；**加载模式**包含：<kbd>DTYMODE</kbd>、<kbd>TOOLMODE</kbd>,<kbd>FILEMODE</kbd>和
<kbd>AUTOMODE</kbd>四种，但当前只使用<kbd>AUTOMODE</kbd>；**适用语言**包含：<kbd>CHINESE</kbd>和<kbd>ENGLISH</kbd>两种，适用语言用于告知解析器对于符号的解析规则（中文模式下，中文、英文符号都需要转义字符，而英文模式下，中文符号不需要转义字符）。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<kbd>Entry</kbd>表示目录部分，目录可以包含多个目录与多个键。  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<kbd>Key</kbd>表示一个项，代表一个键值对。针对**键值**有三种不同的类型，分别是**整数**<kbd>INT</kbd>,**二进制**<kbd>BINARY</kbd>和**字符串**
<kbd>STRING</kbd>。
&emsp;  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如下图所示为**MRX文件的数据结构**。    
![课程管理系统MRX数据结构-(READMEIMG/CMS-MRX-DS.png)](https://github.com/TIANYU-Sky/Course-Management-System/blob/main/READMEIMG/CMS-MRX-DS.png)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数据采用二叉树排序树设计，每个**Entry**节点包含一个子Entry头以及Key链表。MRX的整体结构为层次树。  
&emsp;   
*注：当前为了保证第二次读取文件时的重建效率，所以所有文件输出时都采用树的层次遍历（图的广度优先）方式，保证第二次建立文件时不会出现单列长链（虽然效果也不好 ^v^）*。
&emsp;  
### <span id="Third-2">MRI</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MRI文件模板源于***INI***文件，但在其中加入了针对多行和单行注释的支持。注释方式与**C语言**一致。内部数据结构为复合排序单链表。
&emsp;  