<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원가입</title>
</head>
<body>
	<form method="POST">
		<p>
			아이디 : <input type="text" name="id" />
		</p>
		<p>
			비밀번호 : <input type="text" name="pw" />
		</p>
		<p>
			주소 : <input type="text" name="address" />
		</p>
		<p>
			전화번호 : <input type="text" name="hp" />
		</p>
		<p>
			이메일 : <input type="text" name="e_mail" />
		</p>

		<input type="radio" name="gender" value="man" checked="checked">
		남자  <input type="radio" name="gender" value="woman"> 여자

		<p>
			<input type="submit" value="가입" /> &nbsp; <input type="reset"
				value="취소" />
	</form>


</body>
</html>