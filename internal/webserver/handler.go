package webserver

import (
	router "github.com/qiangxue/fasthttp-routing"
	"github.com/valyala/fasthttp"
)

var (
	staticFileHandler = fasthttp.FS{
		Root:       "./web/dist",
		IndexNames: []string{"index.html"},
		PathRewrite: func(ctx *fasthttp.RequestCtx) []byte {
			return ctx.Path()[7:]
		},
	}
)

func (server *Server) fileServer(ctx *router.Context) error {
	staticFileHandler.NewRequestHandler()(ctx.RequestCtx)
	ctx.Abort()

	return nil
}
