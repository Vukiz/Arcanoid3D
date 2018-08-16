# Arcanoid3D
Test task for Cookies games
3. Прототип игры жанра Arkanoid в 3D
а) Создать проект со сценой, в которой будет прототип игры жанра Arkanoid в режиме 3D.
Условия: 
- 	Мяч должен начинать движение вперёд (под небольшим случайным углом) по клику мыши. 
Движение мяча должно происходить строго в горизонтальной плоскости.
Мяч не должен терять скорость и со временем должен ускоряться до разумного предела. 
Мяч визуально вращается вокруг оси, перпендикулярной его движению, со скоростью сопоставимой с его движением. Мяч отскакивается от бортов игрового поля ровно под углом отражения относительно направления движения.

Бита игрока движется за курсором мыши, движение биты ограничено левым и правым бортами игрового поля. От биты игрока мяч отскакивает не по физике, а относительно точки соприкосновения, чем левее/правее от центра биты, тем больше угол отскока.

В левом верхнем углу экрана располагаются два счётчика (текстовых поля с числами). При каждом касании биты мячом, число первого счётчика увеличивается на 1.
При каждом касании заднего борта игрового поля (который находится за битой игрока), число второго счётчика увеличивается на 1.

б) Для создания прототипа используются примитивы unity (Cube, Sphere) и любая текстура с помощью которой можно визуально увидеть направление вращения мяча.