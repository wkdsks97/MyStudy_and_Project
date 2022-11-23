package com.shopping.team4;
import java.util.Map;

import org.mybatis.spring.SqlSessionTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class UserDao {
	 @Autowired
	 SqlSessionTemplate sqlSessionTemplate;
	 
	 public int insert(Map<String, Object> map) {
		  return this.sqlSessionTemplate.insert("user.insert", map);
		}
	 
	 public Map<String, Object> selectDetail(Map<String, Object> map) {
		    return this.sqlSessionTemplate.selectOne("user.select_detail", map);
		}
	 
	 public int update(Map<String, Object> map) {  
		 return this.sqlSessionTemplate.update("user.update", map);  
		 }  
	 
	 public int idCheck(Map<String, Object> map){
		 int result=  this.sqlSessionTemplate.selectOne("user.idCheck", map);
				 return result;
	 }
}