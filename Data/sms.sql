/*
SQLyog Ultimate v9.33 GA
MySQL - 5.1.49-community : Database - sms
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sms` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `sms`;

/*Table structure for table `sms_account` */

DROP TABLE IF EXISTS `sms_account`;

CREATE TABLE `sms_account` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseID` int(11) NOT NULL,
  `Account` varchar(10) NOT NULL,
  `Password` varchar(36) NOT NULL,
  `Signature` varchar(12) DEFAULT NULL,
  `Level` int(11) DEFAULT '1',
  `State` int(11) DEFAULT '1',
  `Createtime` datetime DEFAULT NULL,
  `LoginTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Data for the table `sms_account` */

insert  into `sms_account`(`ID`,`EnterpriseID`,`Account`,`Password`,`Signature`,`Level`,`State`,`Createtime`,`LoginTime`) values (1,1,'admin','e10adc3949ba59abbe56e057f20f883e','123',NULL,1,'2013-08-28 00:04:00','2013-08-21 00:04:02');

/*Table structure for table `sms_account_channel` */

DROP TABLE IF EXISTS `sms_account_channel`;

CREATE TABLE `sms_account_channel` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AccountID` int(11) NOT NULL,
  `ChannelID` int(11) NOT NULL,
  `Channeltype` int(11) DEFAULT NULL,
  `Sendproportion` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_account_channel` */

/*Table structure for table `sms_addrecord` */

DROP TABLE IF EXISTS `sms_addrecord`;

CREATE TABLE `sms_addrecord` (
  `ID` int(11) NOT NULL,
  `AccountID` int(11) NOT NULL,
  `BeforeAdd` float DEFAULT NULL,
  `AddMount` float DEFAULT NULL,
  `AfterAdd` float DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_addrecord` */

/*Table structure for table `sms_batch` */

DROP TABLE IF EXISTS `sms_batch`;

CREATE TABLE `sms_batch` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '批次ID',
  `AccountID` int(11) NOT NULL COMMENT '帐号ID',
  `MessageState` int(11) DEFAULT NULL COMMENT '信息状态	0:未发送 1:已发送 2:暂停发送 3:正在发送 4:停止发送',
  `BatchName` varchar(200) DEFAULT NULL,
  `Remark` varchar(100) DEFAULT NULL,
  `SmsContent` varchar(2048) DEFAULT NULL COMMENT '信息内容',
  `Msgcount` int(11) DEFAULT NULL COMMENT '包含条数',
  `Msgtype` int(11) DEFAULT NULL COMMENT '信息类型	短信: 1彩信: 2WAPPUSH: 3',
  `Level` int(11) DEFAULT NULL COMMENT '优先级	1最低，5最高',
  `Statereport` bit(1) DEFAULT NULL COMMENT '是否需要状态报告',
  `Customnum` varchar(10) DEFAULT NULL COMMENT '客户扩展码',
  `Begintime` datetime DEFAULT NULL COMMENT '发送时间段 开始时间',
  `Endtime` datetime DEFAULT NULL COMMENT '发送时间段 结束时间',
  `Committime` datetime DEFAULT NULL COMMENT '处理完成时间',
  `Posttime` datetime DEFAULT NULL COMMENT '提交时间',
  `BatchState` int(11) DEFAULT NULL COMMENT '批次状态	0： 初始状态1： 处理完成',
  `MtCount` int(11) DEFAULT NULL,
  `EnterPriseID` int(11) DEFAULT NULL,
  `Createtime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_batch` */

/*Table structure for table `sms_batch_amount` */

DROP TABLE IF EXISTS `sms_batch_amount`;

CREATE TABLE `sms_batch_amount` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BatchID` int(11) DEFAULT NULL COMMENT '过滤后入库的号码数',
  `RealAmount` int(11) DEFAULT NULL,
  `SendAmount` int(11) DEFAULT NULL COMMENT '提交成功数',
  `SuccessAmount` int(11) DEFAULT NULL COMMENT '网关收到的成功',
  `PlanSendCount` int(11) DEFAULT NULL COMMENT '如果是长短信，分段发送时的计划条数，非长短信等于文件记录总数',
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_batch_amount` */

/*Table structure for table `sms_batch_details` */

DROP TABLE IF EXISTS `sms_batch_details`;

CREATE TABLE `sms_batch_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BatchID` int(11) NOT NULL,
  `Msgid` varchar(100) DEFAULT NULL,
  `Smstype` int(11) DEFAULT NULL,
  `ChannelID` int(11) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Content` varchar(2000) DEFAULT NULL,
  `State` int(11) DEFAULT NULL,
  `State_report` varchar(10) DEFAULT NULL,
  `Submittime` datetime DEFAULT NULL,
  `Reporttime` datetime DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_batch_details` */

/*Table structure for table `sms_batch_mt` */

DROP TABLE IF EXISTS `sms_batch_mt`;

CREATE TABLE `sms_batch_mt` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '批次ID',
  `AccountID` int(11) NOT NULL COMMENT '帐号ID',
  `MessageState` int(11) DEFAULT NULL COMMENT '信息状态    0:未发送 1:已发送 2:暂停发送 3:正在发送 4:停止发送',
  `SmsContent` varchar(2048) DEFAULT NULL COMMENT '信息内容',
  `Msgcount` int(11) DEFAULT NULL COMMENT '包含条数',
  `Msg_type` int(11) DEFAULT NULL COMMENT '信息类型    短信: 1彩信: 2WAPPUSH: 3',
  `Level` int(11) DEFAULT NULL COMMENT '优先级    1最低，5最高',
  `State_report` bit(1) DEFAULT NULL COMMENT '是否需要状态报告',
  `Custom_num` varchar(10) DEFAULT NULL COMMENT '客户扩展码',
  `Begin_time` datetime DEFAULT NULL COMMENT '发送时间段 开始时间',
  `End_time` datetime DEFAULT NULL COMMENT '发送时间段 结束时间',
  `Commit_time` datetime DEFAULT NULL COMMENT '处理完成时间',
  `Post_time` datetime DEFAULT NULL COMMENT '提交时间',
  `BatchState` int(11) DEFAULT NULL COMMENT '批次状态    0： 初始状态1： 处理完成',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_batch_mt` */

/*Table structure for table `sms_batch_wait` */

DROP TABLE IF EXISTS `sms_batch_wait`;

CREATE TABLE `sms_batch_wait` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `MtID` int(11) DEFAULT NULL,
  `BatchID` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `MsgCount` int(11) DEFAULT NULL,
  `MsgPack` text,
  `MsgType` int(1) DEFAULT NULL,
  `EnterPriseID` int(11) DEFAULT NULL,
  `MsgCarrier` int(11) DEFAULT NULL COMMENT '1：移动，2：联通，3：电信',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_batch_wait` */

/*Table structure for table `sms_blackphone` */

DROP TABLE IF EXISTS `sms_blackphone`;

CREATE TABLE `sms_blackphone` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Phone` varchar(20) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `EnterpriseID` int(11) DEFAULT NULL,
  `Comment` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_blackphone` */

/*Table structure for table `sms_contact` */

DROP TABLE IF EXISTS `sms_contact`;

CREATE TABLE `sms_contact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) NOT NULL,
  `Sex` int(1) NOT NULL,
  `Birthday` datetime NOT NULL,
  `Mobile` varchar(32) NOT NULL,
  `Comment` varchar(256) DEFAULT NULL,
  `AvailFlag` int(11) NOT NULL,
  `IDCard` varchar(18) DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  `GroupID` int(11) DEFAULT NULL,
  `GroupCode` varchar(64) DEFAULT NULL,
  `EnterpriseId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_contact` */

/*Table structure for table `sms_contactgroup` */

DROP TABLE IF EXISTS `sms_contactgroup`;

CREATE TABLE `sms_contactgroup` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterPriseID` int(11) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `GroupCode` varchar(64) DEFAULT NULL,
  `ParentCode` varchar(64) DEFAULT NULL,
  `GroupOrder` int(11) DEFAULT NULL,
  `AvailFlag` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  `ParentGroupID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_contactgroup` */

/*Table structure for table `sms_contentfilterkey` */

DROP TABLE IF EXISTS `sms_contentfilterkey`;

CREATE TABLE `sms_contentfilterkey` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseID` int(11) DEFAULT NULL,
  `Keyword` varchar(32) DEFAULT NULL,
  `Keytype` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `sms_contentfilterkey` */

/*Table structure for table `sms_deductrecord` */

DROP TABLE IF EXISTS `sms_deductrecord`;

CREATE TABLE `sms_deductrecord` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AccountID` int(11) NOT NULL,
  `BatchID` int(11) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `Deduct_time` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_deductrecord` */

/*Table structure for table `sms_enterprise` */

DROP TABLE IF EXISTS `sms_enterprise`;

CREATE TABLE `sms_enterprise` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseName` varchar(30) DEFAULT NULL,
  `Introduction` varchar(200) DEFAULT NULL,
  `AvailFlag` int(1) DEFAULT '1',
  `Capital` float DEFAULT '0' COMMENT '资金，单位元。',
  `CreateTime` datetime DEFAULT NULL,
  `ExtendNum` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `sms_enterprise` */

insert  into `sms_enterprise`(`ID`,`EnterpriseName`,`Introduction`,`AvailFlag`,`Capital`,`CreateTime`,`ExtendNum`) values (1,'test','test',1,99946.5,'2013-08-22 23:17:53','123'),(2,'13','23',NULL,0,'2013-08-29 23:17:35','122'),(3,'wangjun','',1,0,'2013-09-01 19:45:53','111'),(4,'lindy','',1,9998.5,'2013-09-01 19:49:44','231'),(5,'test1','',1,998,'2013-09-05 20:46:49',NULL);

/*Table structure for table `sms_enterprise_cfg` */

DROP TABLE IF EXISTS `sms_enterprise_cfg`;

CREATE TABLE `sms_enterprise_cfg` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseID` int(11) DEFAULT NULL,
  `CfgKey` varchar(50) DEFAULT NULL,
  `CfgValue` varchar(50) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;

/*Data for the table `sms_enterprise_cfg` */

insert  into `sms_enterprise_cfg`(`ID`,`EnterpriseID`,`CfgKey`,`CfgValue`,`CreateTime`) values (1,NULL,NULL,NULL,NULL),(8,1,'introduction',NULL,'2013-08-29 00:35:05'),(9,1,'smsprice','0.5','2013-08-29 00:35:05'),(10,1,'chinamobile','10000','2013-08-29 00:35:05'),(11,1,'union','10000','2013-08-29 00:35:05'),(12,1,'cdma','10000','2013-08-29 00:35:05'),(13,1,'smslength','12','2013-08-29 00:35:05'),(19,2,'smsprice','0.5','2013-08-29 23:47:35'),(20,2,'chinamobile','111','2013-08-29 23:47:35'),(21,2,'union','123','2013-08-29 23:47:35'),(22,2,'cdma','222','2013-08-29 23:47:35'),(23,2,'smslength','67','2013-08-29 23:47:35'),(24,3,'smsprice','0.05','2013-09-01 19:46:07'),(25,3,'chinamobile','10000','2013-09-01 19:46:07'),(26,3,'union','10000','2013-09-01 19:46:07'),(27,3,'cdma','10000','2013-09-01 19:46:07'),(28,3,'smslength','67','2013-09-01 19:46:07'),(29,4,'smsprice','0.05','2013-09-01 19:49:57'),(30,4,'chinamobile','10000','2013-09-01 19:49:57'),(31,4,'union','10000','2013-09-01 19:49:57'),(32,4,'cdma','10000','2013-09-01 19:49:57'),(33,4,'smslength','67','2013-09-01 19:49:57');

/*Table structure for table `sms_holiday` */

DROP TABLE IF EXISTS `sms_holiday`;

CREATE TABLE `sms_holiday` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `TimeType` tinyint(1) DEFAULT NULL,
  `EnterPriseID` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_holiday` */

/*Table structure for table `sms_mo` */

DROP TABLE IF EXISTS `sms_mo`;

CREATE TABLE `sms_mo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseID` int(11) DEFAULT NULL,
  `ReceiveSpid` varchar(32) DEFAULT NULL,
  `Phone` varchar(32) DEFAULT NULL,
  `Content` varchar(2048) DEFAULT NULL,
  `ReceiveTime` datetime DEFAULT NULL,
  `Readed` int(11) DEFAULT NULL,
  `Responsed` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_mo` */

/*Table structure for table `sms_operator` */

DROP TABLE IF EXISTS `sms_operator`;

CREATE TABLE `sms_operator` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `OperatorName` varchar(30) DEFAULT NULL,
  `Introduction` varchar(200) DEFAULT NULL,
  `OperatorArea` varchar(10) DEFAULT NULL,
  `ContactNmae` varchar(10) DEFAULT NULL,
  `Telphone` varchar(30) DEFAULT NULL,
  `Remark` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_operator` */

/*Table structure for table `sms_teleseg` */

DROP TABLE IF EXISTS `sms_teleseg`;

CREATE TABLE `sms_teleseg` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Phone` varchar(5) DEFAULT NULL,
  `CarrierID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

/*Data for the table `sms_teleseg` */

insert  into `sms_teleseg`(`ID`,`Phone`,`CarrierID`) values (1,'134',1),(2,'135',1),(3,'136',1),(4,'137',1),(5,'138',1),(6,'139',1),(7,'147',1),(8,'150',1),(9,'151',1),(10,'152',1),(11,'157',1),(12,'158',1),(13,'159',1),(14,'182',1),(15,'183',1),(16,'187',1),(17,'188',1),(18,'130',2),(19,'131',2),(20,'132',2),(21,'155',2),(22,'156',2),(23,'185',2),(24,'186',2),(25,'133',3),(26,'180',3),(27,'189',3);

/*Table structure for table `sms_template` */

DROP TABLE IF EXISTS `sms_template`;

CREATE TABLE `sms_template` (
  `ID` bigint(11) NOT NULL AUTO_INCREMENT,
  `EnterpriseID` bigint(11) DEFAULT NULL,
  `SmsContent` varchar(500) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sms_template` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
