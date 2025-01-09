![](https://files.mdnice.com/user/16275/9b5c80c0-b82a-4a48-8220-3d97bafe1d47.png)

# 教程简介

EasySQLite是一个七天.NET 8操作SQLite入门到实战详细教程，主要是对学校班级，学生信息进行管理维护（包含选型、开发、发布、部署）！

## 什么是SQLite？

> SQLite 是一个软件库，实现了自给自足的、无服务器的、零配置的、事务性的 SQL 数据库引擎。SQLite 是在世界上最广泛部署的 SQL 数据库引擎。SQLite 源代码不受版权限制。

SQLite是一个轻量级的嵌入式关系型数据库，它以一个小型的C语言库的形式存在。它是一个自包含、无需服务器、零配置的数据库引擎。与传统的数据库系统不同，SQLite直接读写普通磁盘文件，不需要单独的数据库服务器。它支持标准的SQL查询语言，并提供了事务支持和ACID属性（原子性、一致性、隔离性和持久性）。

- SQLite源码：https://github.com/sqlite/sqlite

## 什么是关系型数据库？

- [非关系型数据库和关系型数据库区别详解](https://mp.weixin.qq.com/s/EL3KvDii2_Z8E5Ji0xQ_8Q)
  
  > 关系型数据库（SQL）库指的是使用关系模型（二维表格模型）来组织数据的数据库，是一种使用结构化查询语言（Structured Query Language，简称SQL）进行数据管理和操作的数据库类型。它采用表格的形式来组织和存储数据，通过定义表之间的关系来建立数据之间的联系。

## SQLite具有以下特点

- 嵌入式：SQLite的库可以轻松地嵌入到应用程序中，不需要独立的数据库服务器进程。
- 无服务器：与大多数数据库系统不同，SQLite不需要单独的数据库服务器，所有数据都存储在一个磁盘文件中。
- 零配置：使用SQLite时，没有任何复杂的配置或管理任务。只需引入SQLite库，并开始使用即可。
- 轻量级：SQLite是一个轻量级的数据库引擎，库文件的大小很小，并且在内存使用方面也非常高效。
- 支持事务：SQLite支持事务操作，可以确保数据的一致性和完整性。
- 跨平台：SQLite可以在多个操作系统上运行，包括Windows、Mac、Linux等。
- 公共领域代码：SQLite的源代码是公共领域的，可以免费用于商业或私人用途。

## 选型、开发详细教程
- [第一天 SQLite 简介](https://mp.weixin.qq.com/s/wCKjqDv2hpvsu-01meSMNA)
- [第二天 在 Windows 上配置 SQLite环境](https://mp.weixin.qq.com/s/fbsLOfE1gQLG3OPpz3UZMA)
- [第三天SQLite快速入门](https://mp.weixin.qq.com/s/wgMDqIdaQsMfOuiLl07ggw)
- [第四天EasySQLite前后端项目框架搭建](https://mp.weixin.qq.com/s/RTqRsTrzn7LdTBcMmBtkVw)
- [第五天引入 SQLite-net ORM 并封装常用方法](https://mp.weixin.qq.com/s/RIT7HnPlrLg5KFtJ6a_Biw)
- [第六天后端班级管理相关接口完善和Swagger自定义配置](https://mp.weixin.qq.com/s/dI6tb7WtOyB6p1iqYraH5g)
- [第七天BootstrapBlazor UI组件库引入（1）](https://mp.weixin.qq.com/s/UIeKSqym8ibLRvDwra8aww)
- [第七天Blazor班级管理页面编写和接口对接（2）](https://mp.weixin.qq.com/s/lpXu5Hx_3F7nf970iBo-5A)
- [第七天Blazor学生管理页面编写和接口对接（3）](https://mp.weixin.qq.com/s/9a6y8Lw1kGSjfddLQhQRoQ)
- [将 EasySQLite 从 .NET 8 升级到 .NET 9](https://mp.weixin.qq.com/s/EN5fu-RvBK-xX8lJMZ5QvA)
- [在 .NET 9 中使用 Scalar 替代 Swagger](https://mp.weixin.qq.com/s/oYYqRa_1Bwn65SdcPWelSQ)

## 发布部署详细教程
- [Windows10 IIS Web服务器安装配置](https://mp.weixin.qq.com/s/oaqypmpHOTLA9_5sF6-W7Q)
- [在IIS上部署ASP.NET Core Web API和Blazor Wasm](https://mp.weixin.qq.com/s/MfScgBu0QMRT3D5aIT5A3w)

## 拓展文章教程
- [10款值得推荐的Blazor UI组件库](https://mp.weixin.qq.com/s/HHqkwpXIi7p3K5eUnTcLTw)
- [全面的ASP.NET Core Blazor简介和快速入门](https://mp.weixin.qq.com/s/hcZBhbTab02HqWqryB_oEA)
- [.NET中使用BootstrapBlazor组件库Table实操篇](https://mp.weixin.qq.com/s/qFHUC9UKg_2wY2jSthI9Kw)

## 使用技术栈和开发环境
咱们的.NET 8操作SQLite入门到实战教程主要使用技术栈为如下所示：
- 数据库：SQLite。
- 前端：Blazor WebAssembly、BootstrapBlazor。
- 后端：ASP.NET Core 8.0 Web API、SQLite-net ORM、AutoMapper、Swagger。
- 项目分层：简单多层架构。
- 开发工具：Visual Studio 2022需要升级为v17.8或者更高版本才支持.NET 8（长期支持 LTS）。

## 前后端框架预览
![](https://files.mdnice.com/user/16275/7f108a02-e748-48f8-80a3-24769a1db8cb.png)

## 项目源码启动

**配置多个启动项目运行：**

![](https://files.mdnice.com/user/16275/d79b51ae-1108-47f9-bb3c-5228b21b6192.png)


![](https://files.mdnice.com/user/16275/75d08d16-bf98-4f35-9999-7682b2649008.png)

![](https://files.mdnice.com/user/16275/18425c76-f6ce-453e-9e84-36f8cbefe7f5.png)

## 项目效果演示
### 后端WebApi

![](https://files.mdnice.com/user/16275/f7b92eb0-774f-403f-b257-65f51b0a173b.png)


### 前端页面

![](https://files.mdnice.com/user/16275/b0b5be3e-33cc-4acc-af5d-fac9d074e5cd.png)

![](https://files.mdnice.com/user/16275/f91e3ef3-7d62-4c89-b71a-b527c0181762.png)

![](https://files.mdnice.com/user/16275/265e08bc-124e-423e-8208-63a2ec3ad7c6.png)

