(function () {
    $(function () {
        //Localhost:2222/Ipersonappservice 下面就类似这种了
        var _personService = abp.services.app.person; //类型于直接访问了Person服务了

        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find('form');

        //添加联系人 执行
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();//默认提交禁用
            if (!_$form.valid()) {
                return;
            }
            var personEditDto = _$form.serializeFormToObject();//序列化表单为对象

            personEditDto.PhoneNumbers = [];
            var phoneNumber = {};

            phoneNumber.PhoneType = personEditDto.PhoneNumberType;
            phoneNumber.Number = personEditDto.PhoneNumberType;

            personEditDto.PhoneNumbers.push(phoneNumber);

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
                $("input[name=Id]").val(data.person.id);
                $("input[name=Name]").val(data.person.name).parent().addClass('focused');
                $("input[name=EmailAddress]").val(data.person.emailAddress).parent().addClass('focused');
                $("input[name=PhoneNumber]").val(data.person.phoneNumbers[0].number).parent().addClass('focused');
                $("input[name=PhoneNumberType]").selectpicker('val', data.person.phoneNumbers[0].phoneType);
                $("input[name=Address]").val(data.person.address).parent().addClass('focused');
                //4-4节
            });
        });
        //弹出的模态框取消时间 取消就重置form表单
        $("#PersonCreateModal").on("hide.bs.modal",
            function () {
                _$form[0].reset();

            });
    });
})();//闭包形式的js 之后的引用不会有太大问题(不会影响js中的其他变量 方法等)