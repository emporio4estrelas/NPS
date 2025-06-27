# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . ./

# Restaura dependências
RUN dotnet restore

# Compila o projeto
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Porta usada pela aplicação
EXPOSE 80

# Comando para iniciar a API
ENTRYPOINT ["dotnet", "PesquisaSatisfacaoApi.dll"]
