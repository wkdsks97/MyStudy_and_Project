<%@ page pageEncoding="UTF-8" contentType="text/html;charset=utf-8"%>
<html>
<head>
<title>정보 수정</title>
</head>
<body>
	<h1>정보 수정</h1>
	<form method="POST">
		<p>
			비밀번호 : <input type="text" name="pw" value="${ data.pw }" />
		</p>
		<p>
			주소 : <input type="text" name="address" value="${ data.address }" />
		</p>
		<p>
			전화번호 : <input type="text" name="hp" value="${ data.hp }" />
		</p>
		<p>
		<input type="radio" name="gender" value="man" >남자 
		 <input type="radio" name="gender" value="woman"> 여자
		</p>
		<p>
			이메일: <input type="text" name="e_mail" value="${ data.e_mail }" />
		</p>
		<p>
			<input type="submit" value="수정" />
	</form>
</body>
</html>
