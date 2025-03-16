## HawtC.PCS


开源的风力机叶片截面铺层参数与结构参数计算软件（Open source software for calculating cross-sectional layer parameters and structure parameters of wind turbine blades）
<br>HawtC.PCS 是开源风力机计算框架OpenWECD当中的一部分，该软件包是为了计算叶片截面特性而开发的，该软件基于经典的层压板理论计算翼型截面的特性参数，尽管该方法的计算精度不如有限元方法，但鉴于该方法实现方便，计算快速等特点，该方法被应用于HawtC.PCS 1.0.000 当中。但是，为了实现高精度计算，该软件包还在开发一个FEM（有限元）模块以对标商软BECAS的计算精度。基于FEM（有限元）方法计算截面特性的方法，将在PCS 2.0版本当中随HawtC2 V2.1.000一起发布。
同时，该软件包继承了HawtC.APIL的相关函数，支持了内部与外部调用，该软件包与HawtC.APIL与HawtC.MoptL的集成，实现了叶片气动-结构-铺层-水动力的一体化设计。该模块托管于github：

查看手册:<br>
中文：- 中文使用/理论手册 !<a href="docs/HawtC2PCS_CH1.md" target="_blank">点击查看</a>
<br>
英文：- The user guide !<a href="docs/HawtC2PCS_EN1.md" target="_blank">check to view </a>



