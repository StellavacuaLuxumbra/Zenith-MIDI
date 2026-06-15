# Zenith MIDI 渲染器 - 编译指南

## 新增功能
已成功添加相机脚本控制功能：
- 启动时可通过文件选择窗口导入 C# 脚本
- 支持控制相机位置 (XYZ)、旋转 (上下/左右/翻滚)、FOV 等参数
- 运行时动态编译和执行用户脚本

## 在 Windows 上编译步骤

### 1. 安装 .NET SDK
1. 访问 https://dotnet.microsoft.com/download
2. 下载并安装 .NET 8.0 SDK
3. 验证安装：打开命令提示符运行 `dotnet --version`

### 2. 编译项目
```bash
# 进入项目目录
cd /path/to/Zenith

# 还原依赖
dotnet restore Zenith.sln

# 编译 Release 版本
dotnet build Zenith.sln -c Release
```

### 3. 发布为独立 EXE
```bash
# 发布为 Windows 独立 executable (包含所有依赖)
dotnet publish Black-Midi-Render/Zenith.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish

# 或者使用 WPF 发布配置 (如果项目是 WPF 应用)
dotnet publish Black-Midi-Render/Zenith.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o ./publish
```

编译后的 EXE 文件将位于 `./publish` 目录中。

## 相机脚本示例

创建一个 `.cs` 文件，例如 `camera_script.cs`：

```csharp
using System;

public class CameraScript
{
    // 此方法在每帧调用
    public static void UpdateFrame(
        ref float viewOffset,    // X 轴偏移
        ref float viewHeight,    // Y 轴高度
        ref float viewPan,       // Z 轴平移
        ref float camAng,        // 垂直旋转角度
        ref float camRot,        // 水平旋转角度
        ref float camSpin,       // 翻滚角度
        ref float FOV,           // 视野角
        ref float viewdist,      // 前方距离
        ref float viewback)      // 后方距离
    {
        // 示例：缓慢旋转相机
        camRot += 0.5f;
        
        // 示例：设置固定 FOV
        FOV = 75.0f;
        
        // 示例：设置相机高度
        viewHeight = 100.0f;
    }
}
```

## 可控制的相机参数

| 参数名 | 描述 | 典型值范围 |
|--------|------|-----------|
| viewOffset | X 轴位置偏移 | -1000 ~ 1000 |
| viewHeight | Y 轴高度 | 0 ~ 500 |
| viewPan | Z 轴前后平移 | -1000 ~ 1000 |
| camAng | 垂直旋转角度 (俯仰) | -90 ~ 90 |
| camRot | 水平旋转角度 (偏航) | 0 ~ 360 |
| camSpin | 翻滚角度 | -180 ~ 180 |
| FOV | 视野角度 | 30 ~ 120 |
| viewdist | 相机前方裁剪距离 | 0.1 ~ 100 |
| viewback | 相机后方裁剪距离 | 100 ~ 10000 |

## 故障排除

### 编译错误
- 确保已安装 .NET 8.0 SDK
- 运行 `dotnet restore` 还原所有 NuGet 包
- 检查项目依赖是否完整

### 运行时错误
- 确保所有依赖的 DLL 文件与 EXE 在同一目录
- 如果是自包含发布，确保使用了 `--self-contained true` 标志

## 文件结构

```
Zenith/
├── Black-Midi-Render/        # 主应用程序项目
│   └── Zenith.csproj
├── ZenithShared/             # 共享库
├── MidiTrailRender/          # MIDI 轨道渲染器
├── ClassicRender/            # 经典渲染器
├── ...                       # 其他渲染器
└── Zenith.sln                # 解决方案文件
```

## 注意事项

1. 相机脚本在渲染循环中每帧调用
2. 脚本中的参数通过 `ref` 传递，直接修改即可生效
3. 脚本编译失败时会显示错误信息，不影响程序继续运行
4. 建议在测试脚本前先备份重要数据
