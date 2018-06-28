(function () {
    $(function () {
        //Localhost:2222/Ipersonappservice 下面就类似这种了
        var _personService = abp.services.app.person; //类型于直接访问了Person存储

        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find('form');

        //添加联系人 执行
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//默认提交禁用
            if (!_$form.valid()) {
                return;
            }
            var personEditDto = _$form.serializeFormToObject();//序列化表单为对象
            abp.ui.setBusy(_$modal);//显示一个提交后的进度条
            //约定大于配置
            _personService.createOrUpdatePerson({ personEditDto }).done(function () {
                _$modal.modal("hide"); //隐藏模态框
                location.reload(); //重新载入
            }).always(function () { //添加失败了也要清楚模态
                abp.ui.clearBusy(_$modal);
            });
        });

        //刷新
        $("#RefreshButton").click(function () {
            refreshPersonList();
        });

        function refreshPersonList() {
            location.reload();
        }
        //删除联系人信息
        $(".delete-person").click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr("data-person-name");
            deletePerson(personId, personName);
        });

        function deletePerson(id, name) {
            abp.message.confirm("是否删除姓名为：" + name + "的联系人信息", function (isConfirmed) {
                if (isConfirmed) {
                    _personService.deletePerson({ id }).done(function () {
                        refreshPersonList();
                    });
                }
            });
        }

        //编辑联系人信息
        $(".edit-person").click(function (e) {
            e.preventDefault();
            var personId = $(this).attr("data-person-id");
            _personService.getPersonForEdit({ id: personId }).done(function (data) {
                $("input[name=Id]").attr(data.person.id);
                $("input[name=Name]").attr(data.person.name);
                $("input[name=EmailAddress]").attr(data.person.emailAddress);
                $("input[name=Address]").attr(data.person.address);
                //4-4节
            });
        });
    });
})();//闭包形式的js 之后的引用不会有太大问题(不会影响js中的其他变量 方法等)