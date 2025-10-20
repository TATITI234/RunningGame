<!DOCTYPE html>
<html lang="ko">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>개쩌는 소개 페이지</title>
  <style>
    @import url('https://fonts.googleapis.com/css2?family=Nanum+Gothic&family=Rajdhani:wght@600&display=swap');

    * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }

    body {
      font-family: 'Nanum Gothic', sans-serif;
      background: linear-gradient(135deg, #0f2027, #203a43, #2c5364);
      color: #fff;
      min-height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
      padding: 20px;
      overflow-x: hidden;
    }

    .container {
      max-width: 900px;
      background: rgba(255, 255, 255, 0.1);
      border-radius: 20px;
      padding: 40px;
      box-shadow: 0 8px 32px rgba(0, 0, 0, 0.7);
      text-align: center;
      backdrop-filter: blur(10px);
      animation: fadeInUp 1.2s ease forwards;
    }

    h1 {
      font-family: 'Rajdhani', sans-serif;
      font-size: 3.5rem;
      margin-bottom: 15px;
      background: linear-gradient(90deg, #ff6a00, #ee0979);
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      animation: textGlow 3s ease-in-out infinite alternate;
    }

    p.intro {
      font-size: 1.3rem;
      margin-bottom: 40px;
      line-height: 1.6;
      color: #ddd;
    }

    .btn {
      display: inline-block;
      background: linear-gradient(90deg, #ff6a00, #ee0979);
      padding: 15px 40px;
      border-radius: 50px;
      font-weight: 700;
      font-size: 1.2rem;
      color: white;
      text-decoration: none;
      box-shadow: 0 4px 15px rgba(238, 9, 121, 0.6);
      transition: transform 0.3s ease, box-shadow 0.3s ease;
    }

    .btn:hover {
      transform: scale(1.1);
      box-shadow: 0 6px 25px rgba(238, 9, 121, 0.9);
    }

    /* 애니메이션 */
    @keyframes fadeInUp {
      0% {
        opacity: 0;
        transform: translateY(40px);
      }
      100% {
        opacity: 1;
        transform: translateY(0);
      }
    }

    @keyframes textGlow {
      0%, 100% {
        text-shadow: 0 0 10px #ff6a00, 0 0 20px #ee0979, 0 0 30px #ff6a00, 0 0 40px #ee0979;
      }
      50% {
        text-shadow: 0 0 20px #ff6a00, 0 0 30px #ee0979, 0 0 40px #ff6a00, 0 0 50px #ee0979;
      }
    }

    /* 반응형 */
    @media (max-width: 600px) {
      h1 {
        font-size: 2.5rem;
      }

      p.intro {
        font-size: 1rem;
      }

      .btn {
        padding: 12px 30px;
        font-size: 1rem;
      }
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>개쩌는 소개 페이지</h1>
    <p class="intro">
      쿠키런을 기반으로 만든 간단한 게임<br />
      당신도 달리시겠습니까?
    </p>
    <a href="#contact" class="btn">지금 바로 런</a>
  </div>
</body>
</html>
