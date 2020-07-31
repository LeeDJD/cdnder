package webserver

import (
	router "github.com/qiangxue/fasthttp-routing"
	"github.com/valyala/fasthttp"
)

// Server Http-Server responisble for REST-API
type Server struct {
	server *fasthttp.Server
	router *router.Router
	config *Config
}

// Config for Server
type Config struct {
	Host string `json:"host"`
}

// NewServer creates new instance of Server
func NewServer(config *Config) (*Server, error) {
	router := router.New()

	server := &Server{
		server: &fasthttp.Server{},
		router: router,
	}

	server.register()

	return server, nil
}

func (server *Server) register() {
	server.router.Use(server.fileServer)

	api := server.router.Group("/api")
}

// RunServer Start Server on Specified Host(Hostname+Port)
func (server *Server) RunServer() error {
	return server.server.ListenAndServe(server.config.Host)
}
