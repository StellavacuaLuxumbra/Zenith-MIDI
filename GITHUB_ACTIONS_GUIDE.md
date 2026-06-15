# GitHub Actions 自动编译指南

## 自动构建已配置完成

已在 `.github/workflows/build.yml` 中配置了完整的 CI/CD 流程。

## 使用方法

### 方法 1：手动触发构建（推荐）

1. 将代码推送到 GitHub 仓库
2. 进入仓库的 **Actions** 标签页
3. 点击左侧的 **"Build Windows EXE"** 工作流
4. 点击 **"Run workflow"** 按钮
5. 选择分支后点击 **"Run workflow"**
6. 等待构建完成（约 2-5 分钟）
7. 在构建详情页面下载 `Zenith-Windows-x64` 或 `Zenith-Linux-x64` 产物

### 方法 2：推送时自动构建

每次推送到 `main` 或 `master` 分支时会自动触发构建。

### 方法 3：创建 Release 版本

创建一个带标签的发布版本，会自动生成 Release 并附带可执行文件：

```bash
git tag v1.0.0
git push origin v1.0.0
```

## 构建产物

- **Windows**: `Zenith.exe` (独立可执行文件，无需安装 .NET)
- **Linux**: `Zenith` (独立二进制文件)

产物将在 GitHub Actions 中保留 30 天。

## 自定义构建

如需修改构建配置，编辑 `.github/workflows/build.yml` 文件：

- 更改 .NET 版本：修改 `dotnet-version`
- 更改目标平台：修改 `-r` 参数 (如 `win-x64`, `linux-x64`, `osx-x64`)
- 调整压缩选项：修改 `EnableCompressionInSingleFile`

## 注意事项

- 首次运行可能需要更长时间（下载依赖）
- 确保仓库已启用 GitHub Actions
- 免费账户每月有 2000 分钟的构建额度
