package com.shopping.team4;

import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserServiceImpl implements UserService {
	@Autowired
	UserDao userDao;

	@Override
	public String create(Map<String, Object> map) {
		int affectRowCount = this.userDao.insert(map);
		if (affectRowCount == 1) {
			return map.get("id").toString();
		}
		return null;

	}
	
	@Override
	public Map<String, Object> detail(Map<String, Object> map){
	    return this.userDao.selectDetail(map);
	}

	
	@Override  
	public boolean edit(Map<String, Object> map) {  
	int affectRowCount = this.userDao.update(map);  
	return affectRowCount == 1;  

	}  
	
	
	
	
	
	
	
	
	
	
	
	
	
	@Override
	public int idCheck(Map<String, Object>map) throws Exception {
		int result = userDao.idCheck(map);
		return result;
	}

}
