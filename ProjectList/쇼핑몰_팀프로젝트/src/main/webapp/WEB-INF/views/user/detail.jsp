<%@ page pageEncoding="UTF-8" contentType="text/html;charset=utf-8"%>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt"%>
<html>
<head>
<title>계정 정보</title>
</head>
<body>
	<h1>정보</h1>
	<p>아이디 : ${data.id}</p>
	<p>비밀번호 : ${data.pw}</p>
	<p>주소: ${ data.address }</p>
	<p>전화번호 :${data.hp}</p>
	<p>성별: ${ data.gender }</p>
	<p>이메일: ${ data.e_mail }</p>
	<p>
		<a href="/update?UserId=${data.id}">수정</a>
	</p>

	<form method="POST" action="/delete">
		<input type="hidden" name="UserId" value="${UserId}" /> 
		<input type="submit" value="삭제" />
	</form>
</body>
</html>