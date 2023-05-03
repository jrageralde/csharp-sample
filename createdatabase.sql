delimiter $$

CREATE DATABASE `roytekdb`; /*!40100 DEFAULT CHARACTER SET latin1 */

CREATE PROCEDURE `roytekdb`.`spRemoveMustChangePwd` (
   uid bigint
)
BEGIN 
   update users set mustchangepwd=0
   where id = uid; 

END

CREATE PROCEDURE `roytekdb`.`spUserMustChangePwd` (
   uid bigint
)

BEGIN
   select ifnull(mustchangepwd,0) as mustchangepwd
   from users
   where id = uid; 

END
CREATE PROCEDURE `roytekdb`.`spgetUserEmail`
(
   uid bigint
)
BEGIN
   select email,smtphost,smtpport
   from users
   where id = uid; 

END

CREATE PROCEDURE `roytekdb`.`spAssignAllUserRoles` 
(
   uiduser bigint
)
BEGIN
  -- first delete all assigned roles
   delete from userroles where iduser=uiduser;

  -- then insert all roles
   insert into userroles (iduser,idrole)
   select uiduser,id from roles;
   
END

CREATE PROCEDURE `roytekdb`.`spUnassignAllUserRoles` 
( 
   uiduser bigint
)
BEGIN

   delete from userroles
   where iduser=uiduser;

END

CREATE PROCEDURE `roytekdb`.`spAssignUserRole` 
(
   uiduser bigint,
   uidrole bigint
)
BEGIN
   
  DECLARE cntAssigned int;

  -- check if already assigned
  select count(*)
  into cntAssigned
  from userroles ur
  where iduser=uiduser and idrole=uidrole; 

  if cntAssigned=0 THEN
	 insert into userroles(iduser,idrole) values (uiduser,uidrole);
  END IF;



END
CREATE DEFINER=`demouser`@`%` PROCEDURE `spGetUserRoles`(
   lid bigint
)
BEGIN
select r.name, ur.idrole,ur.iduser
    from userroles ur left join roles r on ur.idrole = r.id 
    where ur.iduser = lid
    order by r.name;

END

CREATE PROCEDURE `roytekdb`.`spGetAvailableRoles`
( riduser bigint
)
BEGIN
	select r.name,r.id
	from roles r where id not in
		(select  ur.idrole 
			from userroles ur left join roles r1 on ur.idrole = r1.id 
			where ur.iduser = riduser and r1.name is not null)
	order by r.name;

END

CREATE PROCEDURE `roytekdb`.`spUsersDelete` 
(  rid bigint
)
BEGIN
   DELETE FROM USERS WHERE ID = rid;
END

-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`demouser`@`%` PROCEDURE `spUsersAddEdit`(
    uid bigint,
	uloginname varchar(20),
    uactive tinyint,
    umustchangepwd tinyint,
    uemail varchar(200)

   --  ubirthdate varchar(20)
)
BEGIN
   IF uid = 0 THEN 

      Insert Into users (loginname,active,mustchangepwd,email) 
          values (uloginname,uactive,umustchangepwd,uemail); -- ,ubirthdate)

   ELSE  
     
	  update users set 
          loginname=uloginname,
          active=uactive,
          mustchangepwd=umustchangepwd,
          email=uemail
         -- birthdate=ubirthdate
     where id = uid;

   END IF;

END

CREATE DEFINER=`demouser`@`%` PROCEDURE `spGetAllUsers`()
BEGIN
	select id,loginname,active,mustchangepwd,email,smtphost,smtpport,gender,birthdate
	from users
	order by loginname;

END

CREATE DEFINER=`demouser`@`%` PROCEDURE `spGetUserProfile`(liduser bigint)
BEGIN
	select loginname,email,smtphost,smtpport,birthdate,gender,active,mustchangepwd
	from users
	where id = liduser;
END


CREATE DEFINER=`demouser`@`%` PROCEDURE `spUpdateUser`(
   lidUser bigint,
   lloginname varchar(255),
   lemail varchar(255),
   lsmtphost varchar(100),
   lsmtpport varchar(20), 
   lbirthdate datetime,
   lgender varchar(10)
)
BEGIN
	Update users set loginname=lloginName, email=lemail, birthdate=lbirthdate, gender=lgender,
        smtphost = lsmtphost, smtpport=lsmtpport
	where id = liduser;
END

CREATE DEFINER=`demouser`@`%` PROCEDURE `spUpdateUser2`(   lidUser bigint,
   lloginname varchar(255),
   lactive tinyint,
   lmustchangepwd tinyint,
   lemail varchar(255),
   lsmtphost varchar(100),
   lsmtpport varchar(20),
   lbirthdate datetime,
   lgender varchar(10)
)
BEGIN
	Update users set loginname=lloginName, active=lactive,mustchangepwd=lmustchangepwd,
      email=lemail, birthdate=lbirthdate, gender=lgender,
smtphost = lsmtphost, smtpport=lsmtpport
	where id = liduser;
END
CREATE DEFINER=`demouser`@`%` PROCEDURE `spUpdateUserPwd`(
   lidUser bigint,
   lpassword varchar(255)
)
BEGIN
	Update users set password=lpassword
	where id = liduser;
END

CREATE DEFINER=`demouser`@`%` PROCEDURE `spGetUserPhoto`(liduser bigint)
BEGIN
	select photo
	from users
	where id = liduser;
END

CREATE PROCEDURE `roytekdb`.`sprolesAddEdit` 
(
    rid bigint,
    rname varchar(30),
   rdescription varchar(100)
)
BEGIN

    set rname = upper(rname);

    IF rid = 0 THEN 

      Insert Into roles (name,description) values (rname,rdescription);

   ELSE  
     
	  update roles set name=rname, description=rdescription where id = rid;

   END IF;


END

CREATE PROCEDURE `roytekdb`.`sprolesDelete`
(
    rid bigint
)
BEGIN

   Delete from roles where id = rid;

END

CREATE TABLE `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `loginname` varchar(50) NOT NULL,
  `eMail` varchar(100) NOT NULL,
  `password` varchar(255) DEFAULT NULL,
  `smtphost` varchar(100) DEFAULT NULL,
  `smtpport` varchar(20) DEFAULT NULL,
  `active` tinyint(1) DEFAULT '1',
  `mustchangepwd` tinyint(1) DEFAULT '0',
  `birthdate` datetime DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `photo` blob,
  PRIMARY KEY (`id`),
  KEY `Loginname` (`loginname`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1


CREATE TABLE `roles` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1$$

CREATE TABLE `userroles` (
  `id` bigint(20) NOT NULL,
  `iduser` bigint(20) DEFAULT NULL,
  `idrole` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `USER` (`iduser`),
  KEY `ROLE` (`idrole`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1$$


$$

