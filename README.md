# CSharp

.NET으로 만들어진 컴퓨터 이용시간 관리기입니다.

현재 서버가 작동하지 않아 정상적인 사용이 불가능 합니다.

<p align="center"><image src="https://raw.githubusercontent.com/JWHer/CSharp/master/image01.png" width="80%"></p>
<p align="center"><image src="https://raw.githubusercontent.com/JWHer/CSharp/master/image02.png" width="80%"></p>

개발 요구사항  
	1. n분 후 전원 관리(종료/절전)를 시작하는 기능  
	2. 서버에 전원 관리 정보를 기록하는 기능  
	3. 일간 사용량을 로컬 데이터로 저장하여 보여주는 기능  
	4. 컴퓨터 자체적으로 시작, 종료, 기타 전원 관리 변경 시 감지  
	5. 전원 관리의 단축키 지정이 가능  
  
사용된 기술  
	1. timer를 사용하여 n분 후 예약을 수행하고 전원 관리 process를 실행한다.  
	2. HTTPWebComm 클래스를 사용하여 서버와 통신한다. 오래 걸리는 통신은 스레드로 처리해 프로그램이 자연스럽게 동작하도록 한다.  
	3. 데이터 파일을 읽고 쓰는 기능을 추가하고, 레지스트리로부터 경로를 읽어온다.  
	4. wndProc를 오버라이드하여 윈도우 메시지를 후크해 윈도우 상태를 감지한다.  
	5. user32.dll을 사용하여 전원 관리 단축키를 등록한다.  
