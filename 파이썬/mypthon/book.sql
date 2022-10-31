create database myprojectdb;
use myprojectdb;
create table book (
num int auto_increment primary key,
name varchar(5000),
price int);
select * from book;